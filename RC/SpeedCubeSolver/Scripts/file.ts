
export class PixelMapModel {
    public Pixels: RedGreenBluePixelModel[][];
    public Width: number;
    public Height: number;
    public constructor(width: number, height: number) {

        this.Width = width;
        this.Height = height;

        this.Pixels = new Array<Array<RedGreenBluePixelModel>>();
        for (let y = 0; y < height; y++) {
            let row: RedGreenBluePixelModel[] = new Array<RedGreenBluePixelModel>();

            for (let x = 0; x < width; x++) {
                row.push(new RedGreenBluePixelModel(x, y));
            }

            this.Pixels.push(row);
        }
    }
}

export class RedGreenBluePixelModel {
    public constructor(x: number, y: number, red: number = 0, green: number = 0, blue = 0, alpha = 1) {
        this.Red = red;
        this.Green = green;
        this.Blue = blue;
        this.Alpha = alpha;
        this.X = x;
        this.Y = y;
    }

    public Red: number;
    public Green: number;
    public Blue: number;
    public Alpha: number;
    public X: number;
    public Y: number;
}

export class MaskSegmentModel {
    public constructor() {
        this.Width = 0;
        this.Height = 0;

        this.HorizontalStart = 0;
        this.HorizontalEnd = 0;

        this.VerticalStart = 0;
        this.VerticalEnd = 0;

        this.Pixels = new Array<RedGreenBluePixelModel>();

        this.Canvas = <HTMLCanvasElement>document.createElement('canvas');
    }

    public Width: number;
    public Height: number;

    public HorizontalStart: number;
    public HorizontalEnd: number;

    public VerticalStart: number;
    public VerticalEnd: number;

    public Pixels: Array<RedGreenBluePixelModel>;
    public Canvas: HTMLCanvasElement;
}

export class CubeAnalyzer {

    public constructor() {

    }
    
    public ConfigurationInput: HTMLInputElement = {} as HTMLInputElement;
    public ConfigurationButton: HTMLButtonElement = {} as HTMLButtonElement;
    public CubeConfigurationButton: HTMLButtonElement = {} as HTMLButtonElement;

    public VideoFrame: HTMLVideoElement = {} as HTMLVideoElement;
    public LiveCanvas: HTMLCanvasElement = {} as HTMLCanvasElement;
    public CanvasContext: CanvasRenderingContext2D = {} as CanvasRenderingContext2D;
    public Image: HTMLImageElement = {} as HTMLImageElement;
    public ImageOverlay: HTMLImageElement = {} as HTMLImageElement;
    public LiveCanvasMasks: Array<HTMLCanvasElement> = new Array<HTMLCanvasElement>();
    public Masks: Array<MaskSegmentModel> = new Array<MaskSegmentModel>();

    public Loop(): void {
        setTimeout(() => {
            this.AnalyzeCube();
            this.Loop();
        }, 100);
    }

    public Init(): void {
        
        this.ConfigurationInput = document.getElementById("txtConfiguration") as HTMLInputElement;
        this.ConfigurationButton = document.getElementById("btnConfiguration") as HTMLButtonElement;
        this.CubeConfigurationButton = document.getElementById("btnCubeConfiguration") as HTMLButtonElement;

        const inputTopBackLeft = document.getElementById('input-top-back-left') as HTMLInputElement;
        const inputTopBackCenter = document.getElementById('input-top-back-center') as HTMLInputElement;
        const inputTopBackRight = document.getElementById('input-top-back-right') as HTMLInputElement;
        const inputTopCenterLeft = document.getElementById('input-top-center-left') as HTMLInputElement;
        const inputTopCenterCenter = document.getElementById('input-top-center-center') as HTMLInputElement;
        const inputTopCenterRight = document.getElementById('input-top-center-right') as HTMLInputElement;
        const inputTopFrontLeft = document.getElementById('input-top-front-left') as HTMLInputElement;
        const inputTopFrontCenter = document.getElementById('input-top-front-center') as HTMLInputElement;
        const inputTopFrontRight = document.getElementById('input-top-front-right') as HTMLInputElement;

        const inputLeftTopBack = document.getElementById('input-left-top-back') as HTMLInputElement;
        const inputLeftTopCenter = document.getElementById('input-left-top-center') as HTMLInputElement;
        const inputLeftTopFront = document.getElementById('input-left-top-front') as HTMLInputElement;
        const inputLeftCenterBack = document.getElementById('input-left-center-back') as HTMLInputElement;
        const inputLeftCenterCenter = document.getElementById('input-left-center-center') as HTMLInputElement;
        const inputLeftCenterFront = document.getElementById('input-left-center-front') as HTMLInputElement;
        const inputLeftBottomBack = document.getElementById('input-left-bottom-back') as HTMLInputElement;
        const inputLeftBottomCenter = document.getElementById('input-left-bottom-center') as HTMLInputElement;
        const inputLeftBottomFront = document.getElementById('input-left-bottom-front') as HTMLInputElement;

        const inputFrontTopLeft = document.getElementById('input-front-top-left') as HTMLInputElement;
        const inputFrontTopCenter = document.getElementById('input-front-top-center') as HTMLInputElement;
        const inputFrontTopRight = document.getElementById('input-front-top-right') as HTMLInputElement;
        const inputFrontCenterLeft = document.getElementById('input-front-center-left') as HTMLInputElement;
        const inputFrontCenterCenter = document.getElementById('input-front-center-center') as HTMLInputElement;
        const inputFrontCenterRight = document.getElementById('input-front-center-right') as HTMLInputElement;
        const inputFrontBottomLeft = document.getElementById('input-front-bottom-left') as HTMLInputElement;
        const inputFrontBottomCenter = document.getElementById('input-front-bottom-center') as HTMLInputElement;
        const inputFrontBottomRight = document.getElementById('input-front-bottom-right') as HTMLInputElement;

        const inputRightTopFront = document.getElementById('input-right-top-front') as HTMLInputElement;
        const inputRightTopCenter = document.getElementById('input-right-top-center') as HTMLInputElement;
        const inputRightTopBack = document.getElementById('input-right-top-back') as HTMLInputElement;
        const inputRightCenterFront = document.getElementById('input-right-center-front') as HTMLInputElement;
        const inputRightCenterCenter = document.getElementById('input-right-center-center') as HTMLInputElement;
        const inputRightCenterBack = document.getElementById('input-right-center-back') as HTMLInputElement;
        const inputRightBottomFront = document.getElementById('input-right-bottom-front') as HTMLInputElement;
        const inputRightBottomCenter = document.getElementById('input-right-bottom-center') as HTMLInputElement;
        const inputRightBottomBack = document.getElementById('input-right-bottom-back') as HTMLInputElement;

        const inputBackTopLeft = document.getElementById('input-back-top-left') as HTMLInputElement;
        const inputBackTopCenter = document.getElementById('input-back-top-center') as HTMLInputElement;
        const inputBackTopRight = document.getElementById('input-back-top-right') as HTMLInputElement;
        const inputBackCenterLeft = document.getElementById('input-back-center-left') as HTMLInputElement;
        const inputBackCenterCenter = document.getElementById('input-back-center-center') as HTMLInputElement;
        const inputBackCenterRight = document.getElementById('input-back-center-right') as HTMLInputElement;
        const inputBackBottomLeft = document.getElementById('input-back-bottom-left') as HTMLInputElement;
        const inputBackBottomCenter = document.getElementById('input-back-bottom-center') as HTMLInputElement;
        const inputBackBottomRight = document.getElementById('input-back-bottom-right') as HTMLInputElement;

        const inputBottomFrontLeft = document.getElementById('input-bottom-front-left') as HTMLInputElement;
        const inputBottomFrontCenter = document.getElementById('input-bottom-front-center') as HTMLInputElement;
        const inputBottomFrontRight = document.getElementById('input-bottom-front-right') as HTMLInputElement;
        const inputBottomCenterLeft = document.getElementById('input-bottom-center-left') as HTMLInputElement;
        const inputBottomCenterCenter = document.getElementById('input-bottom-center-center') as HTMLInputElement;
        const inputBottomCenterRight = document.getElementById('input-bottom-center-right') as HTMLInputElement;
        const inputBottomBackLeft = document.getElementById('input-bottom-back-left') as HTMLInputElement;
        const inputBottomBackCenter = document.getElementById('input-bottom-back-center') as HTMLInputElement;
        const inputBottomBackRight = document.getElementById('input-bottom-back-right') as HTMLInputElement;

        this.CubeConfigurationButton.onclick = () => {

            const rawConfigurationValue =

                inputRightTopFront.value +
                inputRightTopCenter.value +
                inputRightTopBack.value +
                inputRightCenterFront.value +
                inputRightCenterBack.value +
                inputRightBottomFront.value +
                inputRightBottomCenter.value +
                inputRightBottomBack.value +
                ',' +
                inputTopBackLeft.value +
                inputTopBackCenter.value +
                inputTopBackRight.value +
                inputTopCenterLeft.value +
                inputTopCenterRight.value +
                inputTopFrontLeft.value +
                inputTopFrontCenter.value +
                inputTopFrontRight.value +
                ',' +
                inputFrontTopLeft.value +
                inputFrontTopCenter.value +
                inputFrontTopRight.value +
                inputFrontCenterLeft.value +
                inputFrontCenterRight.value +
                inputFrontBottomLeft.value +
                inputFrontBottomCenter.value +
                inputFrontBottomRight.value +
                ',' +
                inputLeftTopBack.value +
                inputLeftTopCenter.value +
                inputLeftTopFront.value +
                inputLeftCenterBack.value +
                inputLeftCenterFront.value +
                inputLeftBottomBack.value +
                inputLeftBottomCenter.value +
                inputLeftBottomFront.value +
                ',' +
                inputBottomFrontLeft.value +
                inputBottomFrontCenter.value +
                inputBottomFrontRight.value +
                inputBottomCenterLeft.value +
                inputBottomCenterRight .value +
                inputBottomBackLeft.value +
                inputBottomBackCenter.value +
                inputBottomBackRight.value +
                ',' +
                inputBackTopLeft.value +
                inputBackTopCenter.value +
                inputBackTopRight.value +
                inputBackCenterLeft.value +
                inputBackCenterRight.value +
                inputBackBottomLeft.value +
                inputBackBottomCenter.value +
                inputBackBottomRight.value;

            let configurationValue = rawConfigurationValue.trim().toUpperCase();

            configurationValue = configurationValue.trim().toUpperCase().replace(new RegExp(inputRightCenterCenter.value, "g"), 'A');
            configurationValue = configurationValue.trim().toUpperCase().replace(new RegExp(inputTopCenterCenter.value, "g"), 'B');
            configurationValue = configurationValue.trim().toUpperCase().replace(new RegExp(inputFrontCenterCenter.value, "g"), 'C');
            configurationValue = configurationValue.trim().toUpperCase().replace(new RegExp(inputLeftCenterCenter.value, "g"), 'X');
            configurationValue = configurationValue.trim().toUpperCase().replace(new RegExp(inputBottomCenterCenter.value, "g"), 'Y');
            configurationValue = configurationValue.trim().toUpperCase().replace(new RegExp(inputBackCenterCenter.value, "g"), 'Z');

            this.ConfigurationInput.value = configurationValue;

            this.UpdateCubeView(configurationValue.replace(/,/g, ''));
        }

        this.ConfigurationButton.onclick = () => {

            const rawConfigurationValue = this.ConfigurationInput.value.trim().toUpperCase().replace(/,/g, '');

            if (rawConfigurationValue.length !== 54 && rawConfigurationValue.length !== 48) {

                alert('Configuration length must be 54');

            } else {

                const configurationValue: string = this.UpdateCubeView(rawConfigurationValue);

                let i = 0;

                inputRightTopFront.value = configurationValue[i]; i += 1;
                inputRightTopCenter.value = configurationValue[i]; i += 1;
                inputRightTopBack.value = configurationValue[i]; i += 1;
                inputRightCenterFront.value = configurationValue[i]; i += 1;
                inputRightCenterCenter.value = configurationValue[i]; i += 1;
                inputRightCenterBack.value = configurationValue[i]; i += 1;
                inputRightBottomFront.value = configurationValue[i]; i += 1;
                inputRightBottomCenter.value = configurationValue[i]; i += 1;
                inputRightBottomBack.value = configurationValue[i]; i += 1;
 
                inputTopBackLeft.value = configurationValue[i]; i += 1;
                inputTopBackCenter.value = configurationValue[i]; i += 1;
                inputTopBackRight.value = configurationValue[i]; i += 1;
                inputTopCenterLeft.value = configurationValue[i]; i += 1;
                inputTopCenterCenter.value = configurationValue[i]; i += 1;
                inputTopCenterRight.value = configurationValue[i]; i += 1;
                inputTopFrontLeft.value = configurationValue[i]; i += 1;
                inputTopFrontCenter.value = configurationValue[i]; i += 1;
                inputTopFrontRight.value = configurationValue[i]; i += 1;
 
                inputFrontTopLeft.value = configurationValue[i]; i += 1;
                inputFrontTopCenter.value = configurationValue[i]; i += 1;
                inputFrontTopRight.value = configurationValue[i]; i += 1;
                inputFrontCenterLeft.value = configurationValue[i]; i += 1;
                inputFrontCenterCenter.value = configurationValue[i]; i += 1;
                inputFrontCenterRight.value = configurationValue[i]; i += 1;
                inputFrontBottomLeft.value = configurationValue[i]; i += 1;
                inputFrontBottomCenter.value = configurationValue[i]; i += 1;
                inputFrontBottomRight.value = configurationValue[i]; i += 1;
 
                inputLeftTopBack.value = configurationValue[i]; i += 1;
                inputLeftTopCenter.value = configurationValue[i]; i += 1;
                inputLeftTopFront.value = configurationValue[i]; i += 1;
                inputLeftCenterBack.value = configurationValue[i]; i += 1;
                inputLeftCenterCenter.value = configurationValue[i]; i += 1;
                inputLeftCenterFront.value = configurationValue[i]; i += 1;
                inputLeftBottomBack.value = configurationValue[i]; i += 1;
                inputLeftBottomCenter.value = configurationValue[i]; i += 1;
                inputLeftBottomFront.value = configurationValue[i]; i += 1;
 
                inputBottomFrontLeft.value = configurationValue[i]; i += 1;
                inputBottomFrontCenter.value = configurationValue[i]; i += 1;
                inputBottomFrontRight.value = configurationValue[i]; i += 1;
                inputBottomCenterLeft.value = configurationValue[i]; i += 1;
                inputBottomCenterCenter.value = configurationValue[i]; i += 1;
                inputBottomCenterRight.value = configurationValue[i]; i += 1;
                inputBottomBackLeft.value = configurationValue[i]; i += 1;
                inputBottomBackCenter.value = configurationValue[i]; i += 1;
                inputBottomBackRight.value = configurationValue[i]; i += 1;
 
                inputBackTopLeft.value = configurationValue[i]; i += 1;
                inputBackTopCenter.value = configurationValue[i]; i += 1;
                inputBackTopRight.value = configurationValue[i]; i += 1;
                inputBackCenterLeft.value = configurationValue[i]; i += 1;
                inputBackCenterCenter.value = configurationValue[i]; i += 1;
                inputBackCenterRight.value = configurationValue[i]; i += 1;
                inputBackBottomLeft.value = configurationValue[i]; i += 1;
                inputBackBottomCenter.value = configurationValue[i]; i += 1;
                inputBackBottomRight.value = configurationValue[i]; i += 1;
            }
        };


        this.VideoFrame = document.getElementById("myVideo") as HTMLVideoElement;

        this.ImageOverlay = document.getElementById("myVideoOverlay") as HTMLImageElement;

        this.LiveCanvas = document.getElementById("cvsLive") as HTMLCanvasElement;
        this.CanvasContext = this.LiveCanvas.getContext("2d") as CanvasRenderingContext2D;

        let divSegments = document.getElementById("divSegments") as HTMLDivElement;

        //this.SetStartingMasks(divSegments, this.ImageOverlay.width, this.ImageOverlay.width * 0.3, this.ImageOverlay.height * 0.3);

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

    public UpdateCubeView(configurationValue: string): string {

        configurationValue = configurationValue.trim().toUpperCase().replace(/,/g, '');

        if (configurationValue.length === 48) {
            configurationValue = configurationValue.slice(0, 44) + 'Z' + configurationValue.slice(44);
            configurationValue = configurationValue.slice(0, 36) + 'Y' + configurationValue.slice(36);
            configurationValue = configurationValue.slice(0, 28) + 'X' + configurationValue.slice(28);
            configurationValue = configurationValue.slice(0, 20) + 'C' + configurationValue.slice(20);
            configurationValue = configurationValue.slice(0, 12) + 'B' + configurationValue.slice(12);
            configurationValue = configurationValue.slice(0, 4) + 'A' + configurationValue.slice(4);
        }

        const stickerTopBackLeft = document.getElementById('sticker-top-back-left') as HTMLTableCellElement;
        const stickerTopBackCenter = document.getElementById('sticker-top-back-center') as HTMLTableCellElement;
        const stickerTopBackRight = document.getElementById('sticker-top-back-right') as HTMLTableCellElement;
        const stickerTopCenterLeft = document.getElementById('sticker-top-center-left') as HTMLTableCellElement;
        const stickerTopCenterCenter = document.getElementById('sticker-top-center-center') as HTMLTableCellElement;
        const stickerTopCenterRight = document.getElementById('sticker-top-center-right') as HTMLTableCellElement;
        const stickerTopFrontLeft = document.getElementById('sticker-top-front-left') as HTMLTableCellElement;
        const stickerTopFrontCenter = document.getElementById('sticker-top-front-center') as HTMLTableCellElement;
        const stickerTopFrontRight = document.getElementById('sticker-top-front-right') as HTMLTableCellElement;

        const stickerLeftTopBack = document.getElementById('sticker-left-top-back') as HTMLTableCellElement;
        const stickerLeftTopCenter = document.getElementById('sticker-left-top-center') as HTMLTableCellElement;
        const stickerLeftTopFront = document.getElementById('sticker-left-top-front') as HTMLTableCellElement;
        const stickerLeftCenterBack = document.getElementById('sticker-left-center-back') as HTMLTableCellElement;
        const stickerLeftCenterCenter = document.getElementById('sticker-left-center-center') as HTMLTableCellElement;
        const stickerLeftCenterFront = document.getElementById('sticker-left-center-front') as HTMLTableCellElement;
        const stickerLeftBottomBack = document.getElementById('sticker-left-bottom-back') as HTMLTableCellElement;
        const stickerLeftBottomCenter = document.getElementById('sticker-left-bottom-center') as HTMLTableCellElement;
        const stickerLeftBottomFront = document.getElementById('sticker-left-bottom-front') as HTMLTableCellElement;

        const stickerFrontTopLeft = document.getElementById('sticker-front-top-left') as HTMLTableCellElement;
        const stickerFrontTopCenter = document.getElementById('sticker-front-top-center') as HTMLTableCellElement;
        const stickerFrontTopRight = document.getElementById('sticker-front-top-right') as HTMLTableCellElement;
        const stickerFrontCenterLeft = document.getElementById('sticker-front-center-left') as HTMLTableCellElement;
        const stickerFrontCenterCenter = document.getElementById('sticker-front-center-center') as HTMLTableCellElement;
        const stickerFrontCenterRight = document.getElementById('sticker-front-center-right') as HTMLTableCellElement;
        const stickerFrontBottomLeft = document.getElementById('sticker-front-bottom-left') as HTMLTableCellElement;
        const stickerFrontBottomCenter = document.getElementById('sticker-front-bottom-center') as HTMLTableCellElement;
        const stickerFrontBottomRight = document.getElementById('sticker-front-bottom-right') as HTMLTableCellElement;

        const stickerRightTopFront = document.getElementById('sticker-right-top-front') as HTMLTableCellElement;
        const stickerRightTopCenter = document.getElementById('sticker-right-top-center') as HTMLTableCellElement;
        const stickerRightTopBack = document.getElementById('sticker-right-top-back') as HTMLTableCellElement;
        const stickerRightCenterFront = document.getElementById('sticker-right-center-front') as HTMLTableCellElement;
        const stickerRightCenterCenter = document.getElementById('sticker-right-center-center') as HTMLTableCellElement;
        const stickerRightCenterBack = document.getElementById('sticker-right-center-back') as HTMLTableCellElement;
        const stickerRightBottomFront = document.getElementById('sticker-right-bottom-front') as HTMLTableCellElement;
        const stickerRightBottomCenter = document.getElementById('sticker-right-bottom-center') as HTMLTableCellElement;
        const stickerRightBottomBack = document.getElementById('sticker-right-bottom-back') as HTMLTableCellElement;

        const stickerBackTopLeft = document.getElementById('sticker-back-top-left') as HTMLTableCellElement;
        const stickerBackTopCenter = document.getElementById('sticker-back-top-center') as HTMLTableCellElement;
        const stickerBackTopRight = document.getElementById('sticker-back-top-right') as HTMLTableCellElement;
        const stickerBackCenterLeft = document.getElementById('sticker-back-center-left') as HTMLTableCellElement;
        const stickerBackCenterCenter = document.getElementById('sticker-back-center-center') as HTMLTableCellElement;
        const stickerBackCenterRight = document.getElementById('sticker-back-center-right') as HTMLTableCellElement;
        const stickerBackBottomLeft = document.getElementById('sticker-back-bottom-left') as HTMLTableCellElement;
        const stickerBackBottomCenter = document.getElementById('sticker-back-bottom-center') as HTMLTableCellElement;
        const stickerBackBottomRight = document.getElementById('sticker-back-bottom-right') as HTMLTableCellElement;

        const stickerBottomFrontLeft = document.getElementById('sticker-bottom-front-left') as HTMLTableCellElement;
        const stickerBottomFrontCenter = document.getElementById('sticker-bottom-front-center') as HTMLTableCellElement;
        const stickerBottomFrontRight = document.getElementById('sticker-bottom-front-right') as HTMLTableCellElement;
        const stickerBottomCenterLeft = document.getElementById('sticker-bottom-center-left') as HTMLTableCellElement;
        const stickerBottomCenterCenter = document.getElementById('sticker-bottom-center-center') as HTMLTableCellElement;
        const stickerBottomCenterRight = document.getElementById('sticker-bottom-center-right') as HTMLTableCellElement;
        const stickerBottomBackLeft = document.getElementById('sticker-bottom-back-left') as HTMLTableCellElement;
        const stickerBottomBackCenter = document.getElementById('sticker-bottom-back-center') as HTMLTableCellElement;
        const stickerBottomBackRight = document.getElementById('sticker-bottom-back-right') as HTMLTableCellElement;



        let i = 0;

        stickerRightTopFront.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;
        stickerRightTopCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerRightTopBack.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;
        stickerRightCenterFront.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;
        stickerRightCenterCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;
        stickerRightCenterBack.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;
        stickerRightBottomFront.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;
        stickerRightBottomCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;
        stickerRightBottomBack.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;
                

        stickerTopBackLeft.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerTopBackCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerTopBackRight.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerTopCenterLeft.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerTopCenterCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerTopCenterRight.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerTopFrontLeft.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerTopFrontCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerTopFrontRight.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                

        stickerFrontTopLeft.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerFrontTopCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerFrontTopRight.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerFrontCenterLeft.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerFrontCenterCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerFrontCenterRight.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerFrontBottomLeft.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerFrontBottomCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerFrontBottomRight.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                

        stickerLeftTopBack.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerLeftTopCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerLeftTopFront.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerLeftCenterBack.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerLeftCenterCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerLeftCenterFront.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerLeftBottomBack.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerLeftBottomCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerLeftBottomFront.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                

        stickerBottomFrontLeft.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBottomFrontCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBottomFrontRight.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBottomCenterLeft.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBottomCenterCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBottomCenterRight.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBottomBackLeft.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBottomBackCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBottomBackRight.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                

        stickerBackTopLeft.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBackTopCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBackTopRight.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBackCenterLeft.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBackCenterCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBackCenterRight.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBackBottomLeft.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBackBottomCenter.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;                
        stickerBackBottomRight.style.backgroundColor = this.GetColor(configurationValue[i]); i += 1;
        
        return configurationValue;
    }

    //public SetStartingMasks(parentElement: HTMLElement, maskSize: number, horizontalOffset: number, verticalOffset: number): void {

    //    let maskPercent = 0.05;
    //    let maskSegmentSize = Math.floor(maskSize * maskPercent);

    //    let masks = Array<MaskSegmentModel>();
    //    for (let i = 0; i < 9; i++) {

    //        let mask = new MaskSegmentModel();

    //        mask.Width = maskSegmentSize;
    //        mask.Height = maskSegmentSize;

    //        mask.Canvas.width = maskSegmentSize;
    //        mask.Canvas.height = maskSegmentSize;

    //        parentElement.appendChild(mask.Canvas)

    //        masks.push(mask);
    //    }

    //    // X 0 0
    //    // 0 0 0
    //    // 0 0 0
    //    masks[0].HorizontalStart = Math.floor(0 + horizontalOffset);
    //    masks[0].HorizontalEnd = Math.floor(maskSegmentSize + horizontalOffset);

    //    masks[0].VerticalStart = Math.floor(0 + verticalOffset);
    //    masks[0].VerticalEnd = Math.floor(maskSegmentSize + verticalOffset);

    //    // 0 X 0
    //    // 0 0 0
    //    // 0 0 0
    //    masks[1].HorizontalStart = Math.floor(maskSegmentSize * 3 + horizontalOffset);
    //    masks[1].HorizontalEnd = Math.floor(maskSegmentSize * 4 + horizontalOffset);

    //    masks[1].VerticalStart = Math.floor(0 + verticalOffset);
    //    masks[1].VerticalEnd = Math.floor(maskSegmentSize + verticalOffset);

    //    // 0 0 X
    //    // 0 0 0
    //    // 0 0 0
    //    masks[2].HorizontalStart = Math.floor(maskSegmentSize * 6 + horizontalOffset);
    //    masks[2].HorizontalEnd = Math.floor(maskSegmentSize * 7 + horizontalOffset);

    //    masks[2].VerticalStart = Math.floor(0 + verticalOffset);
    //    masks[2].VerticalEnd = Math.floor(maskSegmentSize + verticalOffset);

    //    // 0 0 0
    //    // X 0 0
    //    // 0 0 0
    //    masks[3].HorizontalStart = Math.floor(0 + horizontalOffset);
    //    masks[3].HorizontalEnd = Math.floor(maskSegmentSize + horizontalOffset);

    //    masks[3].VerticalStart = Math.floor(maskSegmentSize * 3 + verticalOffset);
    //    masks[3].VerticalEnd = Math.floor(maskSegmentSize * 4 + verticalOffset);

    //    // 0 0 0
    //    // 0 X 0
    //    // 0 0 0
    //    masks[4].HorizontalStart = Math.floor(maskSegmentSize * 3 + horizontalOffset);
    //    masks[4].HorizontalEnd = Math.floor(maskSegmentSize * 4 + horizontalOffset);

    //    masks[4].VerticalStart = Math.floor(maskSegmentSize * 3 + verticalOffset);
    //    masks[4].VerticalEnd = Math.floor(maskSegmentSize * 4 + verticalOffset);

    //    // 0 0 0
    //    // 0 0 X
    //    // 0 0 0
    //    masks[5].HorizontalStart = Math.floor(maskSegmentSize * 6 + horizontalOffset);
    //    masks[5].HorizontalEnd = Math.floor(maskSegmentSize * 7 + horizontalOffset);

    //    masks[5].VerticalStart = Math.floor(maskSegmentSize * 3 + verticalOffset);
    //    masks[5].VerticalEnd = Math.floor(maskSegmentSize * 4 + verticalOffset);

    //    // 0 0 0
    //    // 0 0 0
    //    // X 0 0
    //    masks[6].HorizontalStart = Math.floor(0 + horizontalOffset);
    //    masks[6].HorizontalEnd = Math.floor(maskSegmentSize + horizontalOffset);

    //    masks[6].VerticalStart = Math.floor(maskSegmentSize * 6 + verticalOffset);
    //    masks[6].VerticalEnd = Math.floor(maskSegmentSize * 7 + verticalOffset);

    //    // 0 0 0
    //    // 0 0 0
    //    // 0 X 0
    //    masks[7].HorizontalStart = Math.floor(maskSegmentSize * 3 + horizontalOffset);
    //    masks[7].HorizontalEnd = Math.floor(maskSegmentSize * 4 + horizontalOffset);

    //    masks[7].VerticalStart = Math.floor(maskSegmentSize * 6 + verticalOffset);
    //    masks[7].VerticalEnd = Math.floor(maskSegmentSize * 7 + verticalOffset);

    //    // 0 0 0
    //    // 0 0 0
    //    // 0 0 X
    //    masks[8].HorizontalStart = Math.floor(maskSegmentSize * 6 + horizontalOffset);
    //    masks[8].HorizontalEnd = Math.floor(maskSegmentSize * 7 + horizontalOffset);

    //    masks[8].VerticalStart = Math.floor(maskSegmentSize * 6 + verticalOffset);
    //    masks[8].VerticalEnd = Math.floor(maskSegmentSize * 7 + verticalOffset);

    //    this.Masks = masks;

    //}

    //  AABYYAAC, BXAXZBZY, CBZYCXBZ, XCXAAYBZ, YCBXCCXX, CZZZBYYA

    public GetColor(arg:string): string {
        const colorPx = 'orange'; 
        const colorPy = 'white';
        const colorPz = 'blue';
        const colorNx = 'red';
        const colorNy = 'yellow';
        const colorNz = 'green';

        let result = 'Error';

        switch (arg) {
            case 'A':
                result = colorPx;
                break;
            case 'B':
                result = colorPy;
                break;
            case 'C':
                result = colorPz;
                break;
            case 'X':
                result = colorNx;
                break;
            case 'Y':
                result = colorNy;
                break;
            case 'Z':
                result = colorNz;
                break;
        }
        return result;
    }

    public AnalyzeCube() {
        let frameWidth = this.LiveCanvas.width;
        let frameHeight = this.LiveCanvas.height;

        this.CanvasContext.drawImage(this.VideoFrame, 0, 0, this.LiveCanvas.width, this.LiveCanvas.height);

        //console.log("analyzecube operation to be performed");

        let image: ImageData = this.CanvasContext.getImageData(0, 0, frameWidth, frameHeight);
        //console.log(image.data.length);
        //console.log(image);

        let lblWidth = <HTMLSpanElement>document.getElementById('lblWidth');
        lblWidth.innerText = frameWidth.toString();

        let lblHeight = <HTMLSpanElement>document.getElementById('lblHeight');
        lblHeight.innerText = frameHeight.toString();

        this.DoStuff(image);

        //this.ApplyImageIntoMask(image, this.Masks);

        this.CanvasContext.putImageData(image, 0, 0);
    }

    public DoStuff(image: ImageData) {

        let channels = image.data.length / 4;
        for (let ic = 0; ic < channels; ic++) {

            let r = image.data[ic * 4];
            let g = image.data[ic * 4 + 1];
            let b = image.data[ic * 4 + 2];

            // image.data[ic * 4 + 3] = 0;

            let baseLine: number = Math.min(r, g, b);

            let rb: number = r - baseLine;
            let gb: number = g - baseLine;
            let bb: number = b - baseLine;

            if ((rb + gb + bb) < 140 || (r + g + b) < 255) {
                image.data[ic * 4] = 0;
                image.data[ic * 4 + 1] = 0;
                image.data[ic * 4 + 2] = 0;
            } else {
                let hue = this.getHue(r, g, b);
                if (hue > 335 || hue <= 5) {
                    //red
                    image.data[ic * 4] = 255;
                    image.data[ic * 4 + 1] = 0;
                    image.data[ic * 4 + 2] = 0;
                }
                else if (hue > 5 && hue <= 32) {
                    //orange 
                    image.data[ic * 4] = 255;
                    image.data[ic * 4 + 1] = 125;
                    image.data[ic * 4 + 2] = 0;
                }
                else if (hue > 32 && hue <= 85) {
                    // Yellow
                    image.data[ic * 4] = 255;
                    image.data[ic * 4 + 1] = 255;
                    image.data[ic * 4 + 2] = 0;
                }
                else if (hue > 85 && hue <= 155) {
                    // Green
                    image.data[ic * 4] = 0;
                    image.data[ic * 4 + 1] = 255;
                    image.data[ic * 4 + 2] = 0;
                }
                else if (hue > 155 && hue <= 280) {
                    // Blue
                    image.data[ic * 4] = 0;
                    image.data[ic * 4 + 1] = 0;
                    image.data[ic * 4 + 2] = 255;
                }
                else if (hue > 280 && hue <= 335) {
                    // Purple
                    image.data[ic * 4] = 149;
                    image.data[ic * 4 + 1] = 33;
                    image.data[ic * 4 + 2] = 246;
                } else {
                    // Error
                    image.data[ic * 4] = 255;
                    image.data[ic * 4 + 1] = 255;
                    image.data[ic * 4 + 2] = 255;
                }
            }
        }

        this.GetRedBox(image);

     }

    public ConvertToPixelMap(image: ImageData): void {

        let pixelMap = new PixelMapModel(image.width, this.Image.height);

        let channels = image.data.length / 4;

        for (let ic = 0; ic < channels; ic++) {

            let r = image.data[ic * 4];
            let g = image.data[ic * 4 + 1];
            let b = image.data[ic * 4 + 2];

            let horizontalPosition = (ic % image.width);
            let verticalPosition = (ic / image.width);

            pixelMap.Pixels[horizontalPosition][verticalPosition] = new RedGreenBluePixelModel(horizontalPosition, verticalPosition, image.data[ic * 4], image.data[ic * 4 + 1], image.data[ic * 4 + 2], image.data[ic * 4 + 3]);
        }
    }
    public GetRedBox(image: ImageData): void {

        let channels = image.data.length / 4;
        for (let ic = 0; ic < channels; ic++) {

            let r = image.data[ic * 4];
            let g = image.data[ic * 4 + 1];
            let b = image.data[ic * 4 + 2];

        }
    }

    public getHue(red: number, green: number, blue: number): number {

        let min = Math.min(Math.min(red, green), blue);
        let max = Math.max(Math.max(red, green), blue);

        if (min == max) {
            return 0;
        }

        let hue = 0;
        if (max == red) {
            hue = (green - blue) / (max - min);

        } else if (max == green) {
            hue = 2 + (blue - red) / (max - min);

        } else {
            hue = 4 + (red - green) / (max - min);
        }

        hue = hue * 60;
        if (hue < 0) hue = hue + 360;

        return Math.round(hue);
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


    //public ApplyImageIntoMask(image: ImageData, masks: Array<MaskSegmentModel>) {

    //    for (let iClear = 0; iClear < masks.length; iClear++) {
    //        masks[iClear].Pixels = new Array<RedGreenBluePixelModel>();
    //    }

    //   let channels = image.data.length / 4;
    //    for (let ic = 0; ic < channels; ic++) {
    //        let horizontalPosition = (ic % image.width);
    //        let verticalPosition = (ic / image.width);

    //        for (let im = 0; im < masks.length; im++) {
    //            if ((horizontalPosition > masks[im].HorizontalStart && horizontalPosition < masks[im].HorizontalEnd)
    //                && (verticalPosition > masks[im].VerticalStart && verticalPosition < masks[im].VerticalEnd)) {

    //                let rgbPixel = new RedGreenBluePixelModel(image.data[ic * 4], image.data[ic * 4 + 1], image.data[ic * 4 + 2], image.data[ic * 4 + 3])

    //                masks[im].Pixels.push(rgbPixel);

    //                image.data[ic * 4] = 0;
    //                image.data[ic * 4 + 1] = 0;
    //                image.data[ic * 4 + 2] = 0;
    //                image.data[ic * 4 + 3] = 0;
    //            }
    //        }
    //    }

    //    for (let im = 0; im < masks.length; im++) {
    //        let canvasContext = <CanvasRenderingContext2D>masks[im].Canvas.getContext("2d");
    //        let imageData = canvasContext.createImageData(masks[im].Width, masks[im].Height); 

    //        for (let ip = 0; ip < masks[im].Pixels.length; ip++) {

    //            imageData.data[ip * 4 + 0] = masks[im].Pixels[ip].Red;
    //            imageData.data[ip * 4 + 1] = masks[im].Pixels[ip].Green;
    //            imageData.data[ip * 4 + 2] = masks[im].Pixels[ip].Blue;
    //            imageData.data[ip * 4 + 3] = masks[im].Pixels[ip].Alpha;
    //        }

    //        canvasContext.putImageData(imageData, 0, 0);
    //    } 
    //}
    public AnalyzePixels(pixel: RedGreenBluePixelModel) {


    }

    public AnalyzePixel(pixel: RedGreenBluePixelModel) {

        let baseLine: number = Math.min(pixel.Red, pixel.Blue, pixel.Green);

        let r: number = pixel.Red - baseLine;
        let g: number = pixel.Green - baseLine;
        let b: number = pixel.Blue - baseLine;

        
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