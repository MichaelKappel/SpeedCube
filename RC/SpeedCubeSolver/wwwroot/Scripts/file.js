System.register([], function (exports_1, context_1) {
    "use strict";
    var RedGreenBluePixelModel, MaskSegmentModel, CubeAnalyzer, ca;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [],
        execute: function () {
            RedGreenBluePixelModel = (function () {
                function RedGreenBluePixelModel(red, green, blue, alpha) {
                    if (red === void 0) { red = 0; }
                    if (green === void 0) { green = 0; }
                    if (blue === void 0) { blue = 0; }
                    if (alpha === void 0) { alpha = 0; }
                    this.Red = red;
                    this.Green = green;
                    this.Blue = blue;
                    this.Alpha = alpha;
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
                    this.DoStuff(image);
                    this.CanvasContext.putImageData(image, 0, 0);
                };
                CubeAnalyzer.prototype.DoStuff = function (image) {
                    var channels = image.data.length / 4;
                    for (var ic = 0; ic < channels; ic++) {
                        var r = image.data[ic * 4];
                        var g = image.data[ic * 4 + 1];
                        var b = image.data[ic * 4 + 2];
                        var baseLine = Math.min(r, g, b);
                        var rb = r - baseLine;
                        var gb = g - baseLine;
                        var bb = b - baseLine;
                        var hue = this.getHue(r, g, b);
                        if (hue > 335 || hue <= 5) {
                            image.data[ic * 4] = 255;
                            image.data[ic * 4 + 1] = 0;
                            image.data[ic * 4 + 2] = 0;
                        }
                        else if (hue > 5 && hue <= 30) {
                            image.data[ic * 4] = 255;
                            image.data[ic * 4 + 1] = 125;
                            image.data[ic * 4 + 2] = 0;
                        }
                        else if (hue > 30 && hue <= 65) {
                            image.data[ic * 4] = 255;
                            image.data[ic * 4 + 1] = 255;
                            image.data[ic * 4 + 2] = 0;
                        }
                        else if (hue > 65 && hue <= 155) {
                            image.data[ic * 4] = 0;
                            image.data[ic * 4 + 1] = 255;
                            image.data[ic * 4 + 2] = 0;
                        }
                        else if (hue > 155 && hue <= 280) {
                            image.data[ic * 4] = 0;
                            image.data[ic * 4 + 1] = 0;
                            image.data[ic * 4 + 2] = 255;
                        }
                        else if (hue > 280 && hue <= 335) {
                            image.data[ic * 4] = 149;
                            image.data[ic * 4 + 1] = 33;
                            image.data[ic * 4 + 2] = 246;
                        }
                        else {
                            image.data[ic * 4] = 255;
                            image.data[ic * 4 + 1] = 255;
                            image.data[ic * 4 + 2] = 255;
                        }
                    }
                };
                CubeAnalyzer.prototype.getHue = function (red, green, blue) {
                    var min = Math.min(Math.min(red, green), blue);
                    var max = Math.max(Math.max(red, green), blue);
                    if (min == max) {
                        return 0;
                    }
                    var hue = 0;
                    if (max == red) {
                        hue = (green - blue) / (max - min);
                    }
                    else if (max == green) {
                        hue = 2 + (blue - red) / (max - min);
                    }
                    else {
                        hue = 4 + (red - green) / (max - min);
                    }
                    hue = hue * 60;
                    if (hue < 0)
                        hue = hue + 360;
                    return Math.round(hue);
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
                CubeAnalyzer.prototype.AnalyzePixels = function (pixel) {
                };
                CubeAnalyzer.prototype.AnalyzePixel = function (pixel) {
                    var baseLine = Math.min(pixel.Red, pixel.Blue, pixel.Green);
                    var r = pixel.Red - baseLine;
                    var g = pixel.Green - baseLine;
                    var b = pixel.Blue - baseLine;
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