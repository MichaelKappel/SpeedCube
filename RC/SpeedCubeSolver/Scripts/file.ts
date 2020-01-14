alert('test 1');

export class MaskSegment {
    public constructor(width: number = 0, height: number = 0, xStart: number = 0, xEnd: number = 0, yStart: number = 0, yEnd: number = 0){
        this.Width = width;
        this.Height = height;

        this.HorizontalStart = xStart;
        this.HorizontalEnd = xEnd;

        this.VerticalStart = yStart;
        this.VerticalEnd = yEnd;
    }

    public Width: number;
    public Height: number;

    public HorizontalStart: number;
    public HorizontalEnd: number;

    public VerticalStart: number;
    public VerticalEnd: number;
}

 export class CubeAnalyzer {

    public constructor() {
        alert('test 2');
    }

     public VideoFrame: HTMLVideoElement = <HTMLVideoElement>{};
     public LiveCanvas: HTMLCanvasElement = <HTMLCanvasElement>{};
     public CanvasContext: CanvasRenderingContext2D = <CanvasRenderingContext2D>{};
     public Image: HTMLImageElement = <HTMLImageElement>{};
     public ImageOverlay: HTMLImageElement = <HTMLImageElement>{};
     public CaptureFlag: Boolean = false;

     public Init(): void {
         this.VideoFrame = <HTMLVideoElement>document.getElementById("myVideo");

         this.ImageOverlay = <HTMLImageElement>document.getElementById("myVideoOverlay");

         this.LiveCanvas = <HTMLCanvasElement>document.getElementById("cvsLive");
         this.CanvasContext = <CanvasRenderingContext2D>this.LiveCanvas.getContext("2d");


         let btnCapture = <HTMLButtonElement>document.getElementById("btnCapture");
         btnCapture.addEventListener("click", () => {
             this.Capture();
         });


         navigator.getUserMedia = (
             //        check for all available media
             //    chrome
             navigator.getUserMedia ||
             (<any>navigator).webkitGetUserMedia ||
             (<any>navigator).mozGetUserMedia ||
             (<any>navigator).msGetUserMedia);

         //this will set a read-only boolean property to the
         //            obtained list of media devices

         if (navigator.getUserMedia) {
             //log ... print in the JS console in browser
             console.log("Browser supports media api");
             //specify what type of media if required.
             /*
                 navigator.getUserMedia({
                         params include :
                             -> video
                             -> audio
                    })
              */

             let successCallback: NavigatorUserMediaSuccessCallback = (stream: any) => {
                 this.success_stream(stream);
             };

             let errorCallback: NavigatorUserMediaErrorCallback = (obj: any) => {
                 this.error_stream(obj);
             };

             navigator.getUserMedia({
                 video: true,
                 //   audio : true, //if microphone access was required
             }, successCallback, errorCallback);

         } else {
             alert("The browser does not support Media Interface");
         }
     }

     public success_stream(stream: MediaStream): void {

        console.log("Streaming successful");

        this.VideoFrame.srcObject = stream;
        this.VideoFrame.play();
    }

    public error_stream(error: string) {
        console.log("error has occured" + error);
    }

    public Capture(): void {
        /*
         When the button is called, this function is called.
         Once the button is clicked, the canvas will be updated with current frame
         */
        this.CaptureFlag = true;
        console.log("Button is clicked");
        this.CanvasContext.drawImage(this.VideoFrame, 0, 0, this.LiveCanvas.width, this.LiveCanvas.height);
    }

    public AdjustLayout(frameWidth: number, frameHeight: number) {

        this.ImageOverlay.style.width = frameWidth.toString();
        this.ImageOverlay.style.height = frameHeight.toString();
        this.ImageOverlay.width = frameWidth;
        this.ImageOverlay.height = frameHeight;

        this.ImageOverlay.style.position = 'relative';
        this.ImageOverlay.style.top = (-frameHeight) + 'px';
        this.ImageOverlay.style.zIndex = (100).toString();

    }

    public CreateMask(frameWidth: number, frameHeight: number): Array<MaskSegment> {

        var maskPercent = 0.1;
        var maskSegmentSize = frameWidth * maskPercent;

        var masks = Array<MaskSegment>();
        for (var i = 0; i < 9; i++) {

            var mask = new MaskSegment();

            mask.Width = frameWidth * maskPercent;
            mask.Height = frameHeight * maskPercent;

            masks.push(mask);
        }

        // X 0 0
        // 0 0 0
        // 0 0 0
        masks[0].HorizontalStart = 0;
        masks[0].HorizontalEnd = maskSegmentSize;

        masks[0].VerticalStart = 0;
        masks[0].VerticalEnd = maskSegmentSize;

        // 0 X 0
        // 0 0 0
        // 0 0 0
        masks[1].HorizontalStart = maskSegmentSize * 2;
        masks[1].HorizontalEnd = maskSegmentSize * 3;

        masks[1].VerticalStart = 0;
        masks[1].VerticalEnd = maskSegmentSize;

        // 0 0 X
        // 0 0 0
        // 0 0 0
        masks[2].HorizontalStart = maskSegmentSize * 5;
        masks[2].HorizontalEnd = maskSegmentSize * 6;

        masks[2].VerticalStart = 0;
        masks[2].VerticalEnd = maskSegmentSize;

        // 0 0 0
        // X 0 0
        // 0 0 0
        masks[3].HorizontalStart = 0;
        masks[3].HorizontalEnd = maskSegmentSize;

        masks[3].VerticalStart = maskSegmentSize * 2;
        masks[3].VerticalEnd = maskSegmentSize * 3;

        // 0 0 0
        // 0 X 0
        // 0 0 0
        masks[4].HorizontalStart = maskSegmentSize * 2;
        masks[4].HorizontalEnd = maskSegmentSize * 3;

        masks[4].VerticalStart = maskSegmentSize * 2;
        masks[4].VerticalEnd = maskSegmentSize * 3;

        // 0 0 0
        // 0 0 X
        // 0 0 0
        masks[5].HorizontalStart = maskSegmentSize * 5;
        masks[5].HorizontalEnd = maskSegmentSize * 6;

        masks[5].VerticalStart = maskSegmentSize * 2;
        masks[5].VerticalEnd = maskSegmentSize * 3;

        // 0 0 0
        // 0 0 0
        // X 0 0
        masks[6].HorizontalStart = 0;
        masks[6].HorizontalEnd = maskSegmentSize;

        masks[6].VerticalStart = maskSegmentSize * 4;
        masks[6].VerticalEnd = maskSegmentSize * 5;

        // 0 0 0
        // 0 0 0
        // 0 X 0
        masks[7].HorizontalStart = maskSegmentSize * 2;
        masks[7].HorizontalEnd = maskSegmentSize * 3;

        masks[7].VerticalStart = maskSegmentSize * 4;
        masks[7].VerticalEnd = maskSegmentSize * 5;

        // 0 0 0
        // 0 0 0
        // 0 0 X
        masks[8].HorizontalStart = maskSegmentSize * 4;
        masks[8].HorizontalEnd = maskSegmentSize * 5;

        masks[8].VerticalStart = maskSegmentSize * 4;
        masks[8].VerticalEnd = maskSegmentSize * 5;

        return masks;

    }

    public AnalyzeCube() {
        var frameWidth = this.LiveCanvas.width;
        var frameHeight = this.LiveCanvas.height;

        this.AdjustLayout(frameWidth, frameHeight);

        this.Capture();

        console.log("analyzecube operation to be performed");

        let image: ImageData = this.CanvasContext.getImageData(0, 0, frameWidth, frameHeight);
        console.log(image.data.length);
        console.log(image);

        var lblWidth = <HTMLSpanElement>document.getElementById('lblWidth');
        lblWidth.innerText = frameWidth.toString();

        var lblHeight = <HTMLSpanElement>document.getElementById('lblHeight');
        lblHeight.innerText = frameHeight.toString();

        var masks = this.CreateMask(frameWidth, frameHeight);
        
        this.CanvasContext.putImageData(image, 0, 0);

        this.SeperateImageIntoThirds(image, frameWidth);
    }

    public ApplyImageIntoMask(image: ImageData, frameWidth: number, masks: Array<MaskSegment>) {

        var channels = image.data.length / 4;
        for (var i = 0; i < channels; i++) {

            var frameWidthRemainder = (i % frameWidth);

           
        }
    }

    public SeperateImageIntoThirds(image: ImageData, frameWidth: number) {

        var channels = image.data.length / 4;
        for (var i = 0; i < channels; i++) {

            var frameWidthRemainder = (i % frameWidth);
            var firstSegmentEnd = (frameWidth / 3);
            var secondSegmentEnd = firstSegmentEnd * 2;

            var firstThird = (channels / 3);
            var secondThird = firstThird * 2;

            var sector;
            var mask;

            if (frameWidthRemainder < firstSegmentEnd) {
                if (i < firstThird) {
                    sector = 0;
                }
                else if (i < secondThird) {
                    sector = 3;
                }
                else {
                    sector = 6;
                }
            } else if (frameWidthRemainder < secondSegmentEnd) {
                if (i < firstThird) {
                    sector = 1;
                }
                else if (i < secondThird) {
                    sector = 4;
                }
                else {
                    sector = 7;
                }
            } else {
                if (i < firstThird) {
                    sector = 2;
                    image.data[i * 4 + 2] = 0.3;
                }
                else if (i < secondThird) {
                    sector = 5;
                }
                else {
                    sector = 8;
                }
            }

            if (sector == 0) {
                image.data[i * 4] = 0;
            }
            else if (sector == 1) {
                image.data[i * 4 + 1] = 0;
            }
            else if (sector == 2) {
                image.data[i * 4 + 2] = 0;
            }
            else if (sector == 3) {
                image.data[i * 4 + 1] = 0;
            }
            else if (sector == 4) {
                image.data[i * 4 + 2] = 0;
            }
            else if (sector == 5) {
                image.data[i * 4] = 0;
            }
            else if (sector == 6) {
                image.data[i * 4 + 2] = 0;
            }
            else if (sector == 7) {
                image.data[i * 4] = 0;
            }
            else if (sector == 8) {
                image.data[i * 4 + 1] = 0;
            }
        }
    }

}

var ca = new CubeAnalyzer();

$(() => {
    ca.Init();
})