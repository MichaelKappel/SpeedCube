System.register([], function (exports_1, context_1) {
    "use strict";
    var MaskSegment, CubeAnalyzer, ca;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [],
        execute: function () {
            alert('test 1');
            MaskSegment = (function () {
                function MaskSegment(width, height, xStart, xEnd, yStart, yEnd) {
                    if (width === void 0) { width = 0; }
                    if (height === void 0) { height = 0; }
                    if (xStart === void 0) { xStart = 0; }
                    if (xEnd === void 0) { xEnd = 0; }
                    if (yStart === void 0) { yStart = 0; }
                    if (yEnd === void 0) { yEnd = 0; }
                    this.Width = width;
                    this.Height = height;
                    this.HorizontalStart = xStart;
                    this.HorizontalEnd = xEnd;
                    this.VerticalStart = yStart;
                    this.VerticalEnd = yEnd;
                }
                return MaskSegment;
            }());
            exports_1("MaskSegment", MaskSegment);
            CubeAnalyzer = (function () {
                function CubeAnalyzer() {
                    this.VideoFrame = {};
                    this.LiveCanvas = {};
                    this.CanvasContext = {};
                    this.Image = {};
                    this.ImageOverlay = {};
                    this.CaptureFlag = false;
                    alert('test 2');
                }
                CubeAnalyzer.prototype.Init = function () {
                    var _this = this;
                    this.VideoFrame = document.getElementById("myVideo");
                    this.ImageOverlay = document.getElementById("myVideoOverlay");
                    this.LiveCanvas = document.getElementById("cvsLive");
                    this.CanvasContext = this.LiveCanvas.getContext("2d");
                    var btnCapture = document.getElementById("btnCapture");
                    btnCapture.addEventListener("click", function () {
                        _this.Capture();
                    });
                    navigator.getUserMedia = (navigator.getUserMedia ||
                        navigator.webkitGetUserMedia ||
                        navigator.mozGetUserMedia ||
                        navigator.msGetUserMedia);
                    if (navigator.getUserMedia) {
                        console.log("Browser supports media api");
                        var successCallback = function (stream) {
                            _this.success_stream(stream);
                        };
                        var errorCallback = function (obj) {
                            _this.error_stream(obj);
                        };
                        navigator.getUserMedia({
                            video: true,
                        }, successCallback, errorCallback);
                    }
                    else {
                        alert("The browser does not support Media Interface");
                    }
                };
                CubeAnalyzer.prototype.success_stream = function (stream) {
                    console.log("Streaming successful");
                    this.VideoFrame.srcObject = stream;
                    this.VideoFrame.play();
                };
                CubeAnalyzer.prototype.error_stream = function (error) {
                    console.log("error has occured" + error);
                };
                CubeAnalyzer.prototype.Capture = function () {
                    this.CaptureFlag = true;
                    console.log("Button is clicked");
                    this.CanvasContext.drawImage(this.VideoFrame, 0, 0, this.LiveCanvas.width, this.LiveCanvas.height);
                };
                CubeAnalyzer.prototype.AdjustLayout = function (frameWidth, frameHeight) {
                    this.ImageOverlay.style.width = frameWidth.toString();
                    this.ImageOverlay.style.height = frameHeight.toString();
                    this.ImageOverlay.width = frameWidth;
                    this.ImageOverlay.height = frameHeight;
                    this.ImageOverlay.style.position = 'relative';
                    this.ImageOverlay.style.top = (-frameHeight) + 'px';
                    this.ImageOverlay.style.zIndex = (100).toString();
                };
                CubeAnalyzer.prototype.CreateMask = function (frameWidth, frameHeight) {
                    var maskPercent = 0.1;
                    var maskSegmentSize = frameWidth * maskPercent;
                    var masks = Array();
                    for (var i = 0; i < 9; i++) {
                        var mask = new MaskSegment();
                        mask.Width = frameWidth * maskPercent;
                        mask.Height = frameHeight * maskPercent;
                        masks.push(mask);
                    }
                    masks[0].HorizontalStart = 0;
                    masks[0].HorizontalEnd = maskSegmentSize;
                    masks[0].VerticalStart = 0;
                    masks[0].VerticalEnd = maskSegmentSize;
                    masks[1].HorizontalStart = maskSegmentSize * 2;
                    masks[1].HorizontalEnd = maskSegmentSize * 3;
                    masks[1].VerticalStart = 0;
                    masks[1].VerticalEnd = maskSegmentSize;
                    masks[2].HorizontalStart = maskSegmentSize * 5;
                    masks[2].HorizontalEnd = maskSegmentSize * 6;
                    masks[2].VerticalStart = 0;
                    masks[2].VerticalEnd = maskSegmentSize;
                    masks[3].HorizontalStart = 0;
                    masks[3].HorizontalEnd = maskSegmentSize;
                    masks[3].VerticalStart = maskSegmentSize * 2;
                    masks[3].VerticalEnd = maskSegmentSize * 3;
                    masks[4].HorizontalStart = maskSegmentSize * 2;
                    masks[4].HorizontalEnd = maskSegmentSize * 3;
                    masks[4].VerticalStart = maskSegmentSize * 2;
                    masks[4].VerticalEnd = maskSegmentSize * 3;
                    masks[5].HorizontalStart = maskSegmentSize * 5;
                    masks[5].HorizontalEnd = maskSegmentSize * 6;
                    masks[5].VerticalStart = maskSegmentSize * 2;
                    masks[5].VerticalEnd = maskSegmentSize * 3;
                    masks[6].HorizontalStart = 0;
                    masks[6].HorizontalEnd = maskSegmentSize;
                    masks[6].VerticalStart = maskSegmentSize * 4;
                    masks[6].VerticalEnd = maskSegmentSize * 5;
                    masks[7].HorizontalStart = maskSegmentSize * 2;
                    masks[7].HorizontalEnd = maskSegmentSize * 3;
                    masks[7].VerticalStart = maskSegmentSize * 4;
                    masks[7].VerticalEnd = maskSegmentSize * 5;
                    masks[8].HorizontalStart = maskSegmentSize * 4;
                    masks[8].HorizontalEnd = maskSegmentSize * 5;
                    masks[8].VerticalStart = maskSegmentSize * 4;
                    masks[8].VerticalEnd = maskSegmentSize * 5;
                    return masks;
                };
                CubeAnalyzer.prototype.AnalyzeCube = function () {
                    var frameWidth = this.LiveCanvas.width;
                    var frameHeight = this.LiveCanvas.height;
                    this.AdjustLayout(frameWidth, frameHeight);
                    this.Capture();
                    console.log("analyzecube operation to be performed");
                    var image = this.CanvasContext.getImageData(0, 0, frameWidth, frameHeight);
                    console.log(image.data.length);
                    console.log(image);
                    var lblWidth = document.getElementById('lblWidth');
                    lblWidth.innerText = frameWidth.toString();
                    var lblHeight = document.getElementById('lblHeight');
                    lblHeight.innerText = frameHeight.toString();
                    var masks = this.CreateMask(frameWidth, frameHeight);
                    this.CanvasContext.putImageData(image, 0, 0);
                    this.SeperateImageIntoThirds(image, frameWidth);
                };
                CubeAnalyzer.prototype.ApplyImageIntoMask = function (image, frameWidth, masks) {
                    var channels = image.data.length / 4;
                    for (var i = 0; i < channels; i++) {
                        var frameWidthRemainder = (i % frameWidth);
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