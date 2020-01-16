export class HueSaturationLightnessPixelModel {
    public constructor(hue: number = 0, saturation: number = 0, lightness = 0) {
        this.Hue = hue;
        this.Saturation = saturation;
        this.Lightness = lightness;
    }

    public Hue: number;
    public Saturation: number;
    public Lightness: number;
}

export class RedGreenBluePixelModel {
    public constructor(red: number = 0, green: number = 0, blue = 0) {
        this.Red = red;
        this.Green = green;
        this.Blue = blue;
    }

    public Red: number;
    public Green: number;
    public Blue: number;
}

export class MaskSegmentModel {
    public constructor() {
        this.Width = 0;
        this.Height = 0;

        this.HorizontalStart = 0;
        this.HorizontalEnd = 0;

        this.VerticalStart = 0;
        this.VerticalEnd = 0;

        this.Pixels = new Array<HueSaturationLightnessPixelModel>();

        this.Canvas = <HTMLCanvasElement>document.createElement('canvas');
    }

    public Width: number;
    public Height: number;

    public HorizontalStart: number;
    public HorizontalEnd: number;

    public VerticalStart: number;
    public VerticalEnd: number;

    public Pixels: Array<HueSaturationLightnessPixelModel>;
    public Canvas: HTMLCanvasElement;
}

export class CubeAnalyzer {

    public constructor() {

    }

    // Start Section adapted from https://gist.github.com/mjackson/5311256
    // color-conversion-algorithms.js by Michael Jackson
    public HslToRgb(pixel: HueSaturationLightnessPixelModel): RedGreenBluePixelModel {
        let r: number, g: number, b: number;

        if (pixel.Saturation == 0) {
            r = g = b = pixel.Lightness; // achromatic
        } else {
            let hue2rgb = (p: number, q: number, t: number): number => {
                if (t < 0) t += 1;
                if (t > 1) t -= 1;
                if (t < 1 / 6) return p + (q - p) * 6 * t;
                if (t < 1 / 2) return q;
                if (t < 2 / 3) return p + (q - p) * (2 / 3 - t) * 6;
                return p;
            };

            let q = pixel.Lightness < 0.5 ? pixel.Lightness * (1 + pixel.Saturation) : pixel.Lightness + pixel.Saturation - pixel.Lightness * pixel.Saturation;
            let p = 2 * pixel.Lightness - q;

            r = hue2rgb(p, q, pixel.Hue + 1 / 3);
            g = hue2rgb(p, q, pixel.Hue);
            b = hue2rgb(p, q, pixel.Hue - 1 / 3);
        }

        return new RedGreenBluePixelModel(r * 255, g * 255, b * 255);
    }

    public RgbToHsl(pixel: RedGreenBluePixelModel): HueSaturationLightnessPixelModel {

        let r = pixel.Red / 255;
        let g = pixel.Green / 255;
        let b = pixel.Blue / 255;

        let max = Math.max(r, g, b), min = Math.min(r, g, b);

        let h: number = 0;
        let s: number = 0;
        let l: number = (max + min) / 2;

        if (max == min) {
            h = s = 0; // achromatic
        } else {
            var d = max - min;
            s = l > 0.5 ? d / (2 - max - min) : d / (max + min);

            switch (max) {
                case r: h = (g - b) / d + (g < b ? 6 : 0); break;
                case g: h = (b - r) / d + 2; break;
                case b: h = (r - g) / d + 4; break;
            }

            h /= 6;
        }

        return new HueSaturationLightnessPixelModel(h, s, l);
    }

    // End Section adapted from https://gist.github.com/mjackson/5311256
    // color-conversion-algorithms.js by Michael Jackson


    public VideoFrame: HTMLVideoElement = <HTMLVideoElement>{};
    public LiveCanvas: HTMLCanvasElement = <HTMLCanvasElement>{};
    public CanvasContext: CanvasRenderingContext2D = <CanvasRenderingContext2D>{};
    public Image: HTMLImageElement = <HTMLImageElement>{};
    public ImageOverlay: HTMLImageElement = <HTMLImageElement>{};
    public LiveCanvasMasks: Array<HTMLCanvasElement> = new Array<HTMLCanvasElement>();
    public Masks: Array<MaskSegmentModel> = new Array<MaskSegmentModel>();

    public Loop(): void {
        setTimeout(() => {
            this.AnalyzeCube();
            this.Loop();
        }, 100);
    }

    public Init(): void {
        this.VideoFrame = <HTMLVideoElement>document.getElementById("myVideo");

        this.ImageOverlay = <HTMLImageElement>document.getElementById("myVideoOverlay");

        this.LiveCanvas = <HTMLCanvasElement>document.getElementById("cvsLive");
        this.CanvasContext = <CanvasRenderingContext2D>this.LiveCanvas.getContext("2d");

        let divSegments = <HTMLDivElement>document.getElementById("divSegments");

        this.SetStartingMasks(divSegments, this.ImageOverlay.width, this.ImageOverlay.width * 0.3, this.ImageOverlay.height * 0.3);

        navigator.getUserMedia = (
            navigator.getUserMedia ||
            (<any>navigator).webkitGetUserMedia ||
            (<any>navigator).mozGetUserMedia ||
            (<any>navigator).msGetUserMedia);     

        if (navigator.getUserMedia) {

            let successCallback: NavigatorUserMediaSuccessCallback = (stream: any) => {
                this.VideoFrame.srcObject = stream;
                this.VideoFrame.play();
            };

            let errorCallback: NavigatorUserMediaErrorCallback = (error: any) => {
                alert("error has occured" + error);
            };

            navigator.getUserMedia({
                video: true,
                //   audio : true, //if microphone access was required
            }, successCallback, errorCallback);

            setTimeout(() => {
                this.Loop();
            }, 100);

        } else {
            alert("The browser does not support Media Interface");
        }
    }

    public SetStartingMasks(parentElement: HTMLElement, maskSize: number, horizontalOffset: number, verticalOffset: number): void {

        let maskPercent = 0.05;
        let maskSegmentSize = Math.floor(maskSize * maskPercent);

        let masks = Array<MaskSegmentModel>();
        for (let i = 0; i < 9; i++) {

            let mask = new MaskSegmentModel();

            mask.Width = maskSegmentSize;
            mask.Height = maskSegmentSize;

            mask.Canvas.width = maskSegmentSize;
            mask.Canvas.height = maskSegmentSize;

            parentElement.appendChild(mask.Canvas)

            masks.push(mask);
        }

        // X 0 0
        // 0 0 0
        // 0 0 0
        masks[0].HorizontalStart = Math.floor(0 + horizontalOffset);
        masks[0].HorizontalEnd = Math.floor(maskSegmentSize + horizontalOffset);

        masks[0].VerticalStart = Math.floor(0 + verticalOffset);
        masks[0].VerticalEnd = Math.floor(maskSegmentSize + verticalOffset);

        // 0 X 0
        // 0 0 0
        // 0 0 0
        masks[1].HorizontalStart = Math.floor(maskSegmentSize * 3 + horizontalOffset);
        masks[1].HorizontalEnd = Math.floor(maskSegmentSize * 4 + horizontalOffset);

        masks[1].VerticalStart = Math.floor(0 + verticalOffset);
        masks[1].VerticalEnd = Math.floor(maskSegmentSize + verticalOffset);

        // 0 0 X
        // 0 0 0
        // 0 0 0
        masks[2].HorizontalStart = Math.floor(maskSegmentSize * 6 + horizontalOffset);
        masks[2].HorizontalEnd = Math.floor(maskSegmentSize * 7 + horizontalOffset);

        masks[2].VerticalStart = Math.floor(0 + verticalOffset);
        masks[2].VerticalEnd = Math.floor(maskSegmentSize + verticalOffset);

        // 0 0 0
        // X 0 0
        // 0 0 0
        masks[3].HorizontalStart = Math.floor(0 + horizontalOffset);
        masks[3].HorizontalEnd = Math.floor(maskSegmentSize + horizontalOffset);

        masks[3].VerticalStart = Math.floor(maskSegmentSize * 3 + verticalOffset);
        masks[3].VerticalEnd = Math.floor(maskSegmentSize * 4 + verticalOffset);

        // 0 0 0
        // 0 X 0
        // 0 0 0
        masks[4].HorizontalStart = Math.floor(maskSegmentSize * 3 + horizontalOffset);
        masks[4].HorizontalEnd = Math.floor(maskSegmentSize * 4 + horizontalOffset);

        masks[4].VerticalStart = Math.floor(maskSegmentSize * 3 + verticalOffset);
        masks[4].VerticalEnd = Math.floor(maskSegmentSize * 4 + verticalOffset);

        // 0 0 0
        // 0 0 X
        // 0 0 0
        masks[5].HorizontalStart = Math.floor(maskSegmentSize * 6 + horizontalOffset);
        masks[5].HorizontalEnd = Math.floor(maskSegmentSize * 7 + horizontalOffset);

        masks[5].VerticalStart = Math.floor(maskSegmentSize * 3 + verticalOffset);
        masks[5].VerticalEnd = Math.floor(maskSegmentSize * 4 + verticalOffset);

        // 0 0 0
        // 0 0 0
        // X 0 0
        masks[6].HorizontalStart = Math.floor(0 + horizontalOffset);
        masks[6].HorizontalEnd = Math.floor(maskSegmentSize + horizontalOffset);

        masks[6].VerticalStart = Math.floor(maskSegmentSize * 6 + verticalOffset);
        masks[6].VerticalEnd = Math.floor(maskSegmentSize * 7 + verticalOffset);

        // 0 0 0
        // 0 0 0
        // 0 X 0
        masks[7].HorizontalStart = Math.floor(maskSegmentSize * 3 + horizontalOffset);
        masks[7].HorizontalEnd = Math.floor(maskSegmentSize * 4 + horizontalOffset);

        masks[7].VerticalStart = Math.floor(maskSegmentSize * 6 + verticalOffset);
        masks[7].VerticalEnd = Math.floor(maskSegmentSize * 7 + verticalOffset);

        // 0 0 0
        // 0 0 0
        // 0 0 X
        masks[8].HorizontalStart = Math.floor(maskSegmentSize * 6 + horizontalOffset);
        masks[8].HorizontalEnd = Math.floor(maskSegmentSize * 7 + horizontalOffset);

        masks[8].VerticalStart = Math.floor(maskSegmentSize * 6 + verticalOffset);
        masks[8].VerticalEnd = Math.floor(maskSegmentSize * 7 + verticalOffset);

        this.Masks = masks;

    }

    public AnalyzeCube() {
        let frameWidth = this.LiveCanvas.width;
        let frameHeight = this.LiveCanvas.height;

        this.CanvasContext.drawImage(this.VideoFrame, 0, 0, this.LiveCanvas.width, this.LiveCanvas.height);

        console.log("analyzecube operation to be performed");

        let image: ImageData = this.CanvasContext.getImageData(0, 0, frameWidth, frameHeight);
        console.log(image.data.length);
        console.log(image);

        let lblWidth = <HTMLSpanElement>document.getElementById('lblWidth');
        lblWidth.innerText = frameWidth.toString();

        let lblHeight = <HTMLSpanElement>document.getElementById('lblHeight');
        lblHeight.innerText = frameHeight.toString();

        this.ApplyImageIntoMask(image, this.Masks);

        this.CanvasContext.putImageData(image, 0, 0);
    }

    public Caluculate() {

    } 

    public MuteColors(image: ImageData, masks: Array<MaskSegmentModel>) {

        let channels = image.data.length / 4;
        for (let ic = 0; ic < channels; ic++) {
            image.data[ic * 4] = image.data[ic * 4];
            image.data[ic * 4 + 1] = 0;
            image.data[ic * 4 + 2] = 0;
            image.data[ic * 4 + 3] = 0;
        }
        for (let im = 0; im < masks.length; im++) {

        }
    }


    public ApplyImageIntoMask(image: ImageData, masks: Array<MaskSegmentModel>) {

        for (let iClear = 0; iClear < masks.length; iClear++) {
            masks[iClear].Pixels = new Array<HueSaturationLightnessPixelModel>();
        }

        let channels = image.data.length / 4;
        for (let ic = 0; ic < channels; ic++) {
            let horizontalPosition = (ic % image.width);
            let verticalPosition = (ic / image.width);

            for (let im = 0; im < masks.length; im++) {
                if ((horizontalPosition > masks[im].HorizontalStart && horizontalPosition < masks[im].HorizontalEnd)
                    && (verticalPosition > masks[im].VerticalStart && verticalPosition < masks[im].VerticalEnd)) {

                    let rgbPixel = new RedGreenBluePixelModel(image.data[ic * 4], image.data[ic * 4 + 1], image.data[ic * 4 + 2])
                    let hslPixel: HueSaturationLightnessPixelModel = this.RgbToHsl(rgbPixel);

                    masks[im].Pixels.push(hslPixel);

                    image.data[ic * 4] = 0;
                    image.data[ic * 4 + 1] = 0;
                    image.data[ic * 4 + 2] = 0;
                    image.data[ic * 4 + 3] = 0;
                }
            }
        }

        for (let im = 0; im < masks.length; im++) {

            let canvasContext = <CanvasRenderingContext2D>masks[im].Canvas.getContext("2d");
            let imageData = canvasContext.createImageData(masks[im].Width, masks[im].Height); 

            for (let ip = 0; ip < masks[im].Pixels.length; ip++) {

                let rgb: RedGreenBluePixelModel = this.HslToRgb(masks[im].Pixels[ip]);
                imageData.data[ip * 4 + 0] = rgb.Red;
                imageData.data[ip * 4 + 1] = rgb.Green;
                imageData.data[ip * 4 + 2] = rgb.Blue;
                imageData.data[ip * 4 + 3] = 1;
            }

            canvasContext.putImageData(imageData, 0, 0);
        } 
    }

    public SeperateImageIntoThirds(image: ImageData, frameWidth: number) {
        let channels = image.data.length / 4;
        for (let i = 0; i < channels; i++) {

            let frameWidthRemainder = (i % frameWidth);
            let firstSegmentEnd = (frameWidth / 3);
            let secondSegmentEnd = firstSegmentEnd * 2;

            let firstThird = (channels / 3);
            let secondThird = firstThird * 2;

            let sector: number;

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

let ca = new CubeAnalyzer();
$(() => {
    ca.Init();
})