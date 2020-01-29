System.register([], function (exports_1, context_1) {
    "use strict";
    var PixelMapModel, RedGreenBluePixelModel, MaskSegmentModel, CubeAnalyzer, ca;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [],
        execute: function () {
            PixelMapModel = (function () {
                function PixelMapModel(width, height) {
                    this.Width = width;
                    this.Height = height;
                    this.Pixels = new Array();
                    for (var y = 0; y < height; y++) {
                        var row = new Array();
                        for (var x = 0; x < width; x++) {
                            row.push(new RedGreenBluePixelModel(x, y));
                        }
                        this.Pixels.push(row);
                    }
                }
                return PixelMapModel;
            }());
            exports_1("PixelMapModel", PixelMapModel);
            RedGreenBluePixelModel = (function () {
                function RedGreenBluePixelModel(x, y, red, green, blue, alpha) {
                    if (red === void 0) { red = 0; }
                    if (green === void 0) { green = 0; }
                    if (blue === void 0) { blue = 0; }
                    if (alpha === void 0) { alpha = 1; }
                    this.Red = red;
                    this.Green = green;
                    this.Blue = blue;
                    this.Alpha = alpha;
                    this.X = x;
                    this.Y = y;
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
                    this.ConfigurationInput = {};
                    this.ConfigurationButton = {};
                    this.CubeConfigurationButton = {};
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
                    this.ConfigurationInput = document.getElementById("txtConfiguration");
                    this.ConfigurationButton = document.getElementById("btnConfiguration");
                    this.CubeConfigurationButton = document.getElementById("btnCubeConfiguration");
                    var inputTopBackLeft = document.getElementById('input-top-back-left');
                    var inputTopBackCenter = document.getElementById('input-top-back-center');
                    var inputTopBackRight = document.getElementById('input-top-back-right');
                    var inputTopCenterLeft = document.getElementById('input-top-center-left');
                    var inputTopCenterCenter = document.getElementById('input-top-center-center');
                    var inputTopCenterRight = document.getElementById('input-top-center-right');
                    var inputTopFrontLeft = document.getElementById('input-top-front-left');
                    var inputTopFrontCenter = document.getElementById('input-top-front-center');
                    var inputTopFrontRight = document.getElementById('input-top-front-right');
                    var inputRightTopFront = document.getElementById('input-right-top-front');
                    var inputRightTopCenter = document.getElementById('input-right-top-center');
                    var inputRightTopBack = document.getElementById('input-right-top-back');
                    var inputRightCenterFront = document.getElementById('input-right-center-front');
                    var inputRightCenterCenter = document.getElementById('input-right-center-center');
                    var inputRightCenterBack = document.getElementById('input-right-center-back');
                    var inputRightBottomFront = document.getElementById('input-right-bottom-front');
                    var inputRightBottomCenter = document.getElementById('input-right-bottom-center');
                    var inputRightBottomBack = document.getElementById('input-right-bottom-back');
                    var inputFrontTopLeft = document.getElementById('input-front-top-left');
                    var inputFrontTopCenter = document.getElementById('input-front-top-center');
                    var inputFrontTopRight = document.getElementById('input-front-top-right');
                    var inputFrontCenterLeft = document.getElementById('input-front-center-left');
                    var inputFrontCenterCenter = document.getElementById('input-front-center-center');
                    var inputFrontCenterRight = document.getElementById('input-front-center-right');
                    var inputFrontBottomLeft = document.getElementById('input-front-bottom-left');
                    var inputFrontBottomCenter = document.getElementById('input-front-bottom-center');
                    var inputFrontBottomRight = document.getElementById('input-front-bottom-right');
                    var inputLeftTopBack = document.getElementById('input-left-top-back');
                    var inputLeftTopCenter = document.getElementById('input-left-top-center');
                    var inputLeftTopFront = document.getElementById('input-left-top-front');
                    var inputLeftCenterBack = document.getElementById('input-left-center-back');
                    var inputLeftCenterCenter = document.getElementById('input-left-center-center');
                    var inputLeftCenterFront = document.getElementById('input-left-center-front');
                    var inputLeftBottomBack = document.getElementById('input-left-bottom-back');
                    var inputLeftBottomCenter = document.getElementById('input-left-bottom-center');
                    var inputLeftBottomFront = document.getElementById('input-left-bottom-front');
                    var inputBottomFrontLeft = document.getElementById('input-bottom-front-left');
                    var inputBottomFrontCenter = document.getElementById('input-bottom-front-center');
                    var inputBottomFrontRight = document.getElementById('input-bottom-front-right');
                    var inputBottomCenterLeft = document.getElementById('input-bottom-center-left');
                    var inputBottomCenterCenter = document.getElementById('input-bottom-center-center');
                    var inputBottomCenterRight = document.getElementById('input-bottom-center-right');
                    var inputBottomBackLeft = document.getElementById('input-bottom-back-left');
                    var inputBottomBackCenter = document.getElementById('input-bottom-back-center');
                    var inputBottomBackRight = document.getElementById('input-bottom-back-right');
                    var inputBackTopLeft = document.getElementById('input-back-top-left');
                    var inputBackTopCenter = document.getElementById('input-back-top-center');
                    var inputBackTopRight = document.getElementById('input-back-top-right');
                    var inputBackCenterLeft = document.getElementById('input-back-center-left');
                    var inputBackCenterCenter = document.getElementById('input-back-center-center');
                    var inputBackCenterRight = document.getElementById('input-back-center-right');
                    var inputBackBottomLeft = document.getElementById('input-back-bottom-left');
                    var inputBackBottomCenter = document.getElementById('input-back-bottom-center');
                    var inputBackBottomRight = document.getElementById('input-back-bottom-right');
                    this.CubeConfigurationButton.onclick = function () {
                        var rawConfigurationValue = inputRightTopFront.value +
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
                            inputBottomCenterRight.value +
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
                        var configurationValue = rawConfigurationValue.trim().toUpperCase();
                        configurationValue = configurationValue.replace(new RegExp(inputRightCenterCenter.value, 'g'), '~1~');
                        configurationValue = configurationValue.replace(new RegExp(inputTopCenterCenter.value, 'g'), '~2~');
                        configurationValue = configurationValue.replace(new RegExp(inputFrontCenterCenter.value, 'g'), '~3~');
                        configurationValue = configurationValue.replace(new RegExp(inputLeftCenterCenter.value, 'g'), '~4~');
                        configurationValue = configurationValue.replace(new RegExp(inputBottomCenterCenter.value, 'g'), '~5~');
                        configurationValue = configurationValue.replace(new RegExp(inputBackCenterCenter.value, 'g'), '~6~');
                        configurationValue = configurationValue.replace(new RegExp('~1~', 'g'), 'A');
                        configurationValue = configurationValue.replace(new RegExp('~2~', 'g'), 'B');
                        configurationValue = configurationValue.replace(new RegExp('~3~', 'g'), 'C');
                        configurationValue = configurationValue.replace(new RegExp('~4~', 'g'), 'X');
                        configurationValue = configurationValue.replace(new RegExp('~5~', 'g'), 'Y');
                        configurationValue = configurationValue.replace(new RegExp('~6~', 'g'), 'Z');
                        _this.ConfigurationInput.value = _this.UpdateCubeView(configurationValue.replace(/,/g, ''));
                    };
                    this.ConfigurationButton.onclick = function () {
                        var rawConfigurationValue = _this.ConfigurationInput.value.trim().toUpperCase().replace(/,/g, '');
                        if (rawConfigurationValue.length !== 54 && rawConfigurationValue.length !== 48) {
                            alert('Configuration length must be 54');
                        }
                        else {
                            var configurationValue = _this.UpdateCubeView(rawConfigurationValue);
                            var i = 0;
                            inputRightTopFront.value = configurationValue[i];
                            i += 1;
                            inputRightTopCenter.value = configurationValue[i];
                            i += 1;
                            inputRightTopBack.value = configurationValue[i];
                            i += 1;
                            inputRightCenterFront.value = configurationValue[i];
                            i += 1;
                            inputRightCenterCenter.value = configurationValue[i];
                            i += 1;
                            inputRightCenterBack.value = configurationValue[i];
                            i += 1;
                            inputRightBottomFront.value = configurationValue[i];
                            i += 1;
                            inputRightBottomCenter.value = configurationValue[i];
                            i += 1;
                            inputRightBottomBack.value = configurationValue[i];
                            i += 1;
                            inputTopBackLeft.value = configurationValue[i];
                            i += 1;
                            inputTopBackCenter.value = configurationValue[i];
                            i += 1;
                            inputTopBackRight.value = configurationValue[i];
                            i += 1;
                            inputTopCenterLeft.value = configurationValue[i];
                            i += 1;
                            inputTopCenterCenter.value = configurationValue[i];
                            i += 1;
                            inputTopCenterRight.value = configurationValue[i];
                            i += 1;
                            inputTopFrontLeft.value = configurationValue[i];
                            i += 1;
                            inputTopFrontCenter.value = configurationValue[i];
                            i += 1;
                            inputTopFrontRight.value = configurationValue[i];
                            i += 1;
                            inputFrontTopLeft.value = configurationValue[i];
                            i += 1;
                            inputFrontTopCenter.value = configurationValue[i];
                            i += 1;
                            inputFrontTopRight.value = configurationValue[i];
                            i += 1;
                            inputFrontCenterLeft.value = configurationValue[i];
                            i += 1;
                            inputFrontCenterCenter.value = configurationValue[i];
                            i += 1;
                            inputFrontCenterRight.value = configurationValue[i];
                            i += 1;
                            inputFrontBottomLeft.value = configurationValue[i];
                            i += 1;
                            inputFrontBottomCenter.value = configurationValue[i];
                            i += 1;
                            inputFrontBottomRight.value = configurationValue[i];
                            i += 1;
                            inputLeftTopBack.value = configurationValue[i];
                            i += 1;
                            inputLeftTopCenter.value = configurationValue[i];
                            i += 1;
                            inputLeftTopFront.value = configurationValue[i];
                            i += 1;
                            inputLeftCenterBack.value = configurationValue[i];
                            i += 1;
                            inputLeftCenterCenter.value = configurationValue[i];
                            i += 1;
                            inputLeftCenterFront.value = configurationValue[i];
                            i += 1;
                            inputLeftBottomBack.value = configurationValue[i];
                            i += 1;
                            inputLeftBottomCenter.value = configurationValue[i];
                            i += 1;
                            inputLeftBottomFront.value = configurationValue[i];
                            i += 1;
                            inputBottomFrontLeft.value = configurationValue[i];
                            i += 1;
                            inputBottomFrontCenter.value = configurationValue[i];
                            i += 1;
                            inputBottomFrontRight.value = configurationValue[i];
                            i += 1;
                            inputBottomCenterLeft.value = configurationValue[i];
                            i += 1;
                            inputBottomCenterCenter.value = configurationValue[i];
                            i += 1;
                            inputBottomCenterRight.value = configurationValue[i];
                            i += 1;
                            inputBottomBackLeft.value = configurationValue[i];
                            i += 1;
                            inputBottomBackCenter.value = configurationValue[i];
                            i += 1;
                            inputBottomBackRight.value = configurationValue[i];
                            i += 1;
                            inputBackTopLeft.value = configurationValue[i];
                            i += 1;
                            inputBackTopCenter.value = configurationValue[i];
                            i += 1;
                            inputBackTopRight.value = configurationValue[i];
                            i += 1;
                            inputBackCenterLeft.value = configurationValue[i];
                            i += 1;
                            inputBackCenterCenter.value = configurationValue[i];
                            i += 1;
                            inputBackCenterRight.value = configurationValue[i];
                            i += 1;
                            inputBackBottomLeft.value = configurationValue[i];
                            i += 1;
                            inputBackBottomCenter.value = configurationValue[i];
                            i += 1;
                            inputBackBottomRight.value = configurationValue[i];
                            i += 1;
                        }
                    };
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
                CubeAnalyzer.prototype.UpdateCubeView = function (configurationValue) {
                    configurationValue = configurationValue.trim().toUpperCase().replace(/,/g, '');
                    if (configurationValue.length === 48) {
                        configurationValue = configurationValue.slice(0, 44) + 'Z' + configurationValue.slice(44);
                        configurationValue = configurationValue.slice(0, 36) + 'Y' + configurationValue.slice(36);
                        configurationValue = configurationValue.slice(0, 28) + 'X' + configurationValue.slice(28);
                        configurationValue = configurationValue.slice(0, 20) + 'C' + configurationValue.slice(20);
                        configurationValue = configurationValue.slice(0, 12) + 'B' + configurationValue.slice(12);
                        configurationValue = configurationValue.slice(0, 4) + 'A' + configurationValue.slice(4);
                    }
                    var stickerTopBackLeft = document.getElementById('sticker-top-back-left');
                    var stickerTopBackCenter = document.getElementById('sticker-top-back-center');
                    var stickerTopBackRight = document.getElementById('sticker-top-back-right');
                    var stickerTopCenterLeft = document.getElementById('sticker-top-center-left');
                    var stickerTopCenterCenter = document.getElementById('sticker-top-center-center');
                    var stickerTopCenterRight = document.getElementById('sticker-top-center-right');
                    var stickerTopFrontLeft = document.getElementById('sticker-top-front-left');
                    var stickerTopFrontCenter = document.getElementById('sticker-top-front-center');
                    var stickerTopFrontRight = document.getElementById('sticker-top-front-right');
                    var stickerLeftTopBack = document.getElementById('sticker-left-top-back');
                    var stickerLeftTopCenter = document.getElementById('sticker-left-top-center');
                    var stickerLeftTopFront = document.getElementById('sticker-left-top-front');
                    var stickerLeftCenterBack = document.getElementById('sticker-left-center-back');
                    var stickerLeftCenterCenter = document.getElementById('sticker-left-center-center');
                    var stickerLeftCenterFront = document.getElementById('sticker-left-center-front');
                    var stickerLeftBottomBack = document.getElementById('sticker-left-bottom-back');
                    var stickerLeftBottomCenter = document.getElementById('sticker-left-bottom-center');
                    var stickerLeftBottomFront = document.getElementById('sticker-left-bottom-front');
                    var stickerFrontTopLeft = document.getElementById('sticker-front-top-left');
                    var stickerFrontTopCenter = document.getElementById('sticker-front-top-center');
                    var stickerFrontTopRight = document.getElementById('sticker-front-top-right');
                    var stickerFrontCenterLeft = document.getElementById('sticker-front-center-left');
                    var stickerFrontCenterCenter = document.getElementById('sticker-front-center-center');
                    var stickerFrontCenterRight = document.getElementById('sticker-front-center-right');
                    var stickerFrontBottomLeft = document.getElementById('sticker-front-bottom-left');
                    var stickerFrontBottomCenter = document.getElementById('sticker-front-bottom-center');
                    var stickerFrontBottomRight = document.getElementById('sticker-front-bottom-right');
                    var stickerRightTopFront = document.getElementById('sticker-right-top-front');
                    var stickerRightTopCenter = document.getElementById('sticker-right-top-center');
                    var stickerRightTopBack = document.getElementById('sticker-right-top-back');
                    var stickerRightCenterFront = document.getElementById('sticker-right-center-front');
                    var stickerRightCenterCenter = document.getElementById('sticker-right-center-center');
                    var stickerRightCenterBack = document.getElementById('sticker-right-center-back');
                    var stickerRightBottomFront = document.getElementById('sticker-right-bottom-front');
                    var stickerRightBottomCenter = document.getElementById('sticker-right-bottom-center');
                    var stickerRightBottomBack = document.getElementById('sticker-right-bottom-back');
                    var stickerBackTopLeft = document.getElementById('sticker-back-top-left');
                    var stickerBackTopCenter = document.getElementById('sticker-back-top-center');
                    var stickerBackTopRight = document.getElementById('sticker-back-top-right');
                    var stickerBackCenterLeft = document.getElementById('sticker-back-center-left');
                    var stickerBackCenterCenter = document.getElementById('sticker-back-center-center');
                    var stickerBackCenterRight = document.getElementById('sticker-back-center-right');
                    var stickerBackBottomLeft = document.getElementById('sticker-back-bottom-left');
                    var stickerBackBottomCenter = document.getElementById('sticker-back-bottom-center');
                    var stickerBackBottomRight = document.getElementById('sticker-back-bottom-right');
                    var stickerBottomFrontLeft = document.getElementById('sticker-bottom-front-left');
                    var stickerBottomFrontCenter = document.getElementById('sticker-bottom-front-center');
                    var stickerBottomFrontRight = document.getElementById('sticker-bottom-front-right');
                    var stickerBottomCenterLeft = document.getElementById('sticker-bottom-center-left');
                    var stickerBottomCenterCenter = document.getElementById('sticker-bottom-center-center');
                    var stickerBottomCenterRight = document.getElementById('sticker-bottom-center-right');
                    var stickerBottomBackLeft = document.getElementById('sticker-bottom-back-left');
                    var stickerBottomBackCenter = document.getElementById('sticker-bottom-back-center');
                    var stickerBottomBackRight = document.getElementById('sticker-bottom-back-right');
                    var i = 0;
                    stickerRightTopFront.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerRightTopCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerRightTopBack.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerRightCenterFront.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerRightCenterCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerRightCenterBack.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerRightBottomFront.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerRightBottomCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerRightBottomBack.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerTopBackLeft.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerTopBackCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerTopBackRight.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerTopCenterLeft.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerTopCenterCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerTopCenterRight.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerTopFrontLeft.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerTopFrontCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerTopFrontRight.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerFrontTopLeft.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerFrontTopCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerFrontTopRight.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerFrontCenterLeft.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerFrontCenterCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerFrontCenterRight.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerFrontBottomLeft.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerFrontBottomCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerFrontBottomRight.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerLeftTopBack.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerLeftTopCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerLeftTopFront.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerLeftCenterBack.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerLeftCenterCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerLeftCenterFront.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerLeftBottomBack.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerLeftBottomCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerLeftBottomFront.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBottomFrontLeft.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBottomFrontCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBottomFrontRight.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBottomCenterLeft.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBottomCenterCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBottomCenterRight.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBottomBackLeft.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBottomBackCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBottomBackRight.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBackTopLeft.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBackTopCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBackTopRight.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBackCenterLeft.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBackCenterCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBackCenterRight.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBackBottomLeft.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBackBottomCenter.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    stickerBackBottomRight.style.backgroundColor = this.GetColor(configurationValue[i]);
                    i += 1;
                    return configurationValue;
                };
                CubeAnalyzer.prototype.GetColor = function (arg) {
                    var colorPx = 'orange';
                    var colorPy = 'white';
                    var colorPz = 'blue';
                    var colorNx = 'red';
                    var colorNy = 'yellow';
                    var colorNz = 'green';
                    var result = 'Error';
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
                };
                CubeAnalyzer.prototype.AnalyzeCube = function () {
                    var frameWidth = this.LiveCanvas.width;
                    var frameHeight = this.LiveCanvas.height;
                    this.CanvasContext.drawImage(this.VideoFrame, 0, 0, this.LiveCanvas.width, this.LiveCanvas.height);
                    var image = this.CanvasContext.getImageData(0, 0, frameWidth, frameHeight);
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
                        if ((rb + gb + bb) < 140 || (r + g + b) < 255) {
                            image.data[ic * 4] = 0;
                            image.data[ic * 4 + 1] = 0;
                            image.data[ic * 4 + 2] = 0;
                        }
                        else {
                            var hue = this.getHue(r, g, b);
                            if (hue > 335 || hue <= 5) {
                                image.data[ic * 4] = 255;
                                image.data[ic * 4 + 1] = 0;
                                image.data[ic * 4 + 2] = 0;
                            }
                            else if (hue > 5 && hue <= 32) {
                                image.data[ic * 4] = 255;
                                image.data[ic * 4 + 1] = 125;
                                image.data[ic * 4 + 2] = 0;
                            }
                            else if (hue > 32 && hue <= 85) {
                                image.data[ic * 4] = 255;
                                image.data[ic * 4 + 1] = 255;
                                image.data[ic * 4 + 2] = 0;
                            }
                            else if (hue > 85 && hue <= 155) {
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
                    }
                    this.GetRedBox(image);
                };
                CubeAnalyzer.prototype.ConvertToPixelMap = function (image) {
                    var pixelMap = new PixelMapModel(image.width, this.Image.height);
                    var channels = image.data.length / 4;
                    for (var ic = 0; ic < channels; ic++) {
                        var r = image.data[ic * 4];
                        var g = image.data[ic * 4 + 1];
                        var b = image.data[ic * 4 + 2];
                        var horizontalPosition = (ic % image.width);
                        var verticalPosition = (ic / image.width);
                        pixelMap.Pixels[horizontalPosition][verticalPosition] = new RedGreenBluePixelModel(horizontalPosition, verticalPosition, image.data[ic * 4], image.data[ic * 4 + 1], image.data[ic * 4 + 2], image.data[ic * 4 + 3]);
                    }
                };
                CubeAnalyzer.prototype.GetRedBox = function (image) {
                    var channels = image.data.length / 4;
                    for (var ic = 0; ic < channels; ic++) {
                        var r = image.data[ic * 4];
                        var g = image.data[ic * 4 + 1];
                        var b = image.data[ic * 4 + 2];
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