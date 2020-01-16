System.register([], function (exports_1, context_1) {
    "use strict";
    var HueSaturationLightnessPixelModel, RedGreenBluePixelModel, MaskSegmentModel, CubeAnalyzer, ca;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [],
        execute: function () {
            HueSaturationLightnessPixelModel = (function () {
                function HueSaturationLightnessPixelModel(hue, saturation, lightness) {
                    if (hue === void 0) { hue = 0; }
                    if (saturation === void 0) { saturation = 0; }
                    if (lightness === void 0) { lightness = 0; }
                    this.Hue = hue;
                    this.Saturation = saturation;
                    this.Lightness = lightness;
                }
                return HueSaturationLightnessPixelModel;
            }());
            exports_1("HueSaturationLightnessPixelModel", HueSaturationLightnessPixelModel);
            RedGreenBluePixelModel = (function () {
                function RedGreenBluePixelModel(red, green, blue) {
                    if (red === void 0) { red = 0; }
                    if (green === void 0) { green = 0; }
                    if (blue === void 0) { blue = 0; }
                    this.Red = red;
                    this.Green = green;
                    this.Blue = blue;
                }
                return RedGreenBluePixelModel;
            }());
            exports_1("RedGreenBluePixelModel", RedGreenBluePixelModel);
            MaskSegmentModel = (function () {
                function MaskSegmentModel() {
                    this.Width = 0;
                    this.Height = 0;
                    this.HorizontalStart = 0;
                    this.HorizontalEnd = 0;
                    this.VerticalStart = 0;
                    this.VerticalEnd = 0;
                    this.Pixels = new Array();
                    this.Canvas = document.createElement('canvas');
                }
                return MaskSegmentModel;
            }());
            exports_1("MaskSegmentModel", MaskSegmentModel);
            CubeAnalyzer = (function () {
                function CubeAnalyzer() {
                    this.VideoFrame = {};
                    this.LiveCanvas = {};
                    this.CanvasContext = {};
                    this.Image = {};
                    this.ImageOverlay = {};
                    this.LiveCanvasMasks = new Array();
                    this.Masks = new Array();
                }
                CubeAnalyzer.prototype.HslToRgb = function (pixel) {
                    var r, g, b;
                    if (pixel.Saturation == 0) {
                        r = g = b = pixel.Lightness;
                    }
                    else {
                        var hue2rgb = function (p, q, t) {
                            if (t < 0)
                                t += 1;
                            if (t > 1)
                                t -= 1;
                            if (t < 1 / 6)
                                return p + (q - p) * 6 * t;
                            if (t < 1 / 2)
                                return q;
                            if (t < 2 / 3)
                                return p + (q - p) * (2 / 3 - t) * 6;
                            return p;
                        };
                        var q = pixel.Lightness < 0.5 ? pixel.Lightness * (1 + pixel.Saturation) : pixel.Lightness + pixel.Saturation - pixel.Lightness * pixel.Saturation;
                        var p = 2 * pixel.Lightness - q;
                        r = hue2rgb(p, q, pixel.Hue + 1 / 3);
                        g = hue2rgb(p, q, pixel.Hue);
                        b = hue2rgb(p, q, pixel.Hue - 1 / 3);
                    }
                    return new RedGreenBluePixelModel(r * 255, g * 255, b * 255);
                };
                CubeAnalyzer.prototype.RgbToHsl = function (pixel) {
                    var r = pixel.Red / 255;
                    var g = pixel.Green / 255;
                    var b = pixel.Blue / 255;
                    var max = Math.max(r, g, b), min = Math.min(r, g, b);
                    var h = 0;
                    var s = 0;
                    var l = (max + min) / 2;
                    if (max == min) {
                        h = s = 0;
                    }
                    else {
                        var d = max - min;
                        s = l > 0.5 ? d / (2 - max - min) : d / (max + min);
                        switch (max) {
                            case r:
                                h = (g - b) / d + (g < b ? 6 : 0);
                                break;
                            case g:
                                h = (b - r) / d + 2;
                                break;
                            case b:
                                h = (r - g) / d + 4;
                                break;
                        }
                        h /= 6;
                    }
                    return new HueSaturationLightnessPixelModel(h, s, l);
                };
                CubeAnalyzer.prototype.Loop = function () {
                    var _this = this;
                    setTimeout(function () {
                        _this.AnalyzeCube();
                        _this.Loop();
                    }, 100);
                };
                CubeAnalyzer.prototype.Init = function () {
                    var _this = this;
                    this.VideoFrame = document.getElementById("myVideo");
                    this.ImageOverlay = document.getElementById("myVideoOverlay");
                    this.LiveCanvas = document.getElementById("cvsLive");
                    this.CanvasContext = this.LiveCanvas.getContext("2d");
                    var divSegments = document.getElementById("divSegments");
                    this.SetStartingMasks(divSegments, this.ImageOverlay.width, this.ImageOverlay.width * 0.3, this.ImageOverlay.height * 0.3);
                    navigator.getUserMedia = (navigator.getUserMedia ||
                        navigator.webkitGetUserMedia ||
                        navigator.mozGetUserMedia ||
                        navigator.msGetUserMedia);
                    if (navigator.getUserMedia) {
                        var successCallback = function (stream) {
                            _this.VideoFrame.srcObject = stream;
                            _this.VideoFrame.play();
                        };
                        var errorCallback = function (error) {
                            alert("error has occured" + error);
                        };
                        navigator.getUserMedia({
                            video: true,
                        }, successCallback, errorCallback);
                        setTimeout(function () {
                            _this.Loop();
                        }, 100);
                    }
                    else {
                        alert("The browser does not support Media Interface");
                    }
                };
                CubeAnalyzer.prototype.SetStartingMasks = function (parentElement, maskSize, horizontalOffset, verticalOffset) {
                    var maskPercent = 0.05;
                    var maskSegmentSize = Math.floor(maskSize * maskPercent);
                    var masks = Array();
                    for (var i = 0; i < 9; i++) {
                        var mask = new MaskSegmentModel();
                        mask.Width = maskSegmentSize;
                        mask.Height = maskSegmentSize;
                        mask.Canvas.width = maskSegmentSize;
                        mask.Canvas.height = maskSegmentSize;
                        parentElement.appendChild(mask.Canvas);
                        masks.push(mask);
                    }
                    masks[0].HorizontalStart = Math.floor(0 + horizontalOffset);
                    masks[0].HorizontalEnd = Math.floor(maskSegmentSize + horizontalOffset);
                    masks[0].VerticalStart = Math.floor(0 + verticalOffset);
                    masks[0].VerticalEnd = Math.floor(maskSegmentSize + verticalOffset);
                    masks[1].HorizontalStart = Math.floor(maskSegmentSize * 3 + horizontalOffset);
                    masks[1].HorizontalEnd = Math.floor(maskSegmentSize * 4 + horizontalOffset);
                    masks[1].VerticalStart = Math.floor(0 + verticalOffset);
                    masks[1].VerticalEnd = Math.floor(maskSegmentSize + verticalOffset);
                    masks[2].HorizontalStart = Math.floor(maskSegmentSize * 6 + horizontalOffset);
                    masks[2].HorizontalEnd = Math.floor(maskSegmentSize * 7 + horizontalOffset);
                    masks[2].VerticalStart = Math.floor(0 + verticalOffset);
                    masks[2].VerticalEnd = Math.floor(maskSegmentSize + verticalOffset);
                    masks[3].HorizontalStart = Math.floor(0 + horizontalOffset);
                    masks[3].HorizontalEnd = Math.floor(maskSegmentSize + horizontalOffset);
                    masks[3].VerticalStart = Math.floor(maskSegmentSize * 3 + verticalOffset);
                    masks[3].VerticalEnd = Math.floor(maskSegmentSize * 4 + verticalOffset);
                    masks[4].HorizontalStart = Math.floor(maskSegmentSize * 3 + horizontalOffset);
                    masks[4].HorizontalEnd = Math.floor(maskSegmentSize * 4 + horizontalOffset);
                    masks[4].VerticalStart = Math.floor(maskSegmentSize * 3 + verticalOffset);
                    masks[4].VerticalEnd = Math.floor(maskSegmentSize * 4 + verticalOffset);
                    masks[5].HorizontalStart = Math.floor(maskSegmentSize * 6 + horizontalOffset);
                    masks[5].HorizontalEnd = Math.floor(maskSegmentSize * 7 + horizontalOffset);
                    masks[5].VerticalStart = Math.floor(maskSegmentSize * 3 + verticalOffset);
                    masks[5].VerticalEnd = Math.floor(maskSegmentSize * 4 + verticalOffset);
                    masks[6].HorizontalStart = Math.floor(0 + horizontalOffset);
                    masks[6].HorizontalEnd = Math.floor(maskSegmentSize + horizontalOffset);
                    masks[6].VerticalStart = Math.floor(maskSegmentSize * 6 + verticalOffset);
                    masks[6].VerticalEnd = Math.floor(maskSegmentSize * 7 + verticalOffset);
                    masks[7].HorizontalStart = Math.floor(maskSegmentSize * 3 + horizontalOffset);
                    masks[7].HorizontalEnd = Math.floor(maskSegmentSize * 4 + horizontalOffset);
                    masks[7].VerticalStart = Math.floor(maskSegmentSize * 6 + verticalOffset);
                    masks[7].VerticalEnd = Math.floor(maskSegmentSize * 7 + verticalOffset);
                    masks[8].HorizontalStart = Math.floor(maskSegmentSize * 6 + horizontalOffset);
                    masks[8].HorizontalEnd = Math.floor(maskSegmentSize * 7 + horizontalOffset);
                    masks[8].VerticalStart = Math.floor(maskSegmentSize * 6 + verticalOffset);
                    masks[8].VerticalEnd = Math.floor(maskSegmentSize * 7 + verticalOffset);
                    this.Masks = masks;
                };
                CubeAnalyzer.prototype.AnalyzeCube = function () {
                    var frameWidth = this.LiveCanvas.width;
                    var frameHeight = this.LiveCanvas.height;
                    this.CanvasContext.drawImage(this.VideoFrame, 0, 0, this.LiveCanvas.width, this.LiveCanvas.height);
                    console.log("analyzecube operation to be performed");
                    var image = this.CanvasContext.getImageData(0, 0, frameWidth, frameHeight);
                    console.log(image.data.length);
                    console.log(image);
                    var lblWidth = document.getElementById('lblWidth');
                    lblWidth.innerText = frameWidth.toString();
                    var lblHeight = document.getElementById('lblHeight');
                    lblHeight.innerText = frameHeight.toString();
                    this.ApplyImageIntoMask(image, this.Masks);
                    this.CanvasContext.putImageData(image, 0, 0);
                };
                CubeAnalyzer.prototype.Caluculate = function () {
                };
                CubeAnalyzer.prototype.MuteColors = function (image, masks) {
                    var channels = image.data.length / 4;
                    for (var ic = 0; ic < channels; ic++) {
                        image.data[ic * 4] = image.data[ic * 4];
                        image.data[ic * 4 + 1] = 0;
                        image.data[ic * 4 + 2] = 0;
                        image.data[ic * 4 + 3] = 0;
                    }
                    for (var im = 0; im < masks.length; im++) {
                    }
                };
                CubeAnalyzer.prototype.ApplyImageIntoMask = function (image, masks) {
                    for (var iClear = 0; iClear < masks.length; iClear++) {
                        masks[iClear].Pixels = new Array();
                    }
                    var channels = image.data.length / 4;
                    for (var ic = 0; ic < channels; ic++) {
                        var horizontalPosition = (ic % image.width);
                        var verticalPosition = (ic / image.width);
                        for (var im = 0; im < masks.length; im++) {
                            if ((horizontalPosition > masks[im].HorizontalStart && horizontalPosition < masks[im].HorizontalEnd)
                                && (verticalPosition > masks[im].VerticalStart && verticalPosition < masks[im].VerticalEnd)) {
                                var rgbPixel = new RedGreenBluePixelModel(image.data[ic * 4], image.data[ic * 4 + 1], image.data[ic * 4 + 2]);
                                var hslPixel = this.RgbToHsl(rgbPixel);
                                masks[im].Pixels.push(hslPixel);
                                image.data[ic * 4] = 0;
                                image.data[ic * 4 + 1] = 0;
                                image.data[ic * 4 + 2] = 0;
                                image.data[ic * 4 + 3] = 0;
                            }
                        }
                    }
                    for (var im = 0; im < masks.length; im++) {
                        var canvasContext = masks[im].Canvas.getContext("2d");
                        var imageData = canvasContext.createImageData(masks[im].Width, masks[im].Height);
                        for (var ip = 0; ip < masks[im].Pixels.length; ip++) {
                            var rgb = this.HslToRgb(masks[im].Pixels[ip]);
                            imageData.data[ip * 4 + 0] = rgb.Red;
                            imageData.data[ip * 4 + 1] = rgb.Green;
                            imageData.data[ip * 4 + 2] = rgb.Blue;
                            imageData.data[ip * 4 + 3] = 1;
                        }
                        canvasContext.putImageData(imageData, 0, 0);
                    }
                };
                CubeAnalyzer.prototype.SeperateImageIntoThirds = function (image, frameWidth) {
                    var channels = image.data.length / 4;
                    for (var i = 0; i < channels; i++) {
                        var frameWidthRemainder = (i % frameWidth);
                        var firstSegmentEnd = (frameWidth / 3);
                        var secondSegmentEnd = firstSegmentEnd * 2;
                        var firstThird = (channels / 3);
                        var secondThird = firstThird * 2;
                        var sector = void 0;
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
                        }
                        else if (frameWidthRemainder < secondSegmentEnd) {
                            if (i < firstThird) {
                                sector = 1;
                            }
                            else if (i < secondThird) {
                                sector = 4;
                            }
                            else {
                                sector = 7;
                            }
                        }
                        else {
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
                };
                return CubeAnalyzer;
            }());
            exports_1("CubeAnalyzer", CubeAnalyzer);
            ca = new CubeAnalyzer();
            $(function () {
                ca.Init();
            });
        }
    };
});
//# sourceMappingURL=file.js.map