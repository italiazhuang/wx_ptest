﻿var pageID = 1082;
var baseURL = "";
var assetsPath = "";
var imageManager = new ImageManager();
var map = new PathFindingMap();
var background = null;
var startGameImage = null;
var moreGamesImage = null;
var pauseMenuImage = null;
var quitImage = null;
var continue2Image = null;
var practiceImage = null;
var logoJ = null;
var logoE1 = null;
var logoW = null;
var logoE2 = null;
var logoL = null;
var logo5 = null;
var cloud1 = null;
var cloud2 = null;
var timeCover = null;
var gameOverImage = null;
var continueImage = null;
var gameSurface = null;
var gameSurfaceContext = null;
var gameWidth = 670;
var gameHeight = 542;
var objects = null;
var overlay = null;
var selected = null;
var selectedMarker = null;
var selectedY = 0;
var selectedX = 0;
var switching = new Array();
var switchingComplete = new Array();
var toDelete = new Array();
var currentFalling = new Array();
var lastFallList = new Array();
var defaultTimeout = 250;
var finishedTimer = 0;
var matchValue = 125;
var scoreTotal = 0;
var topleftOffset = 15;
var gameTimer = 0;
var targetTimer = 0;
var inGame = false;
var isGameOver = false;
var isPaused = false;
var baseTimer = 2600;
var enableSound = false;

var buttonClickSound = null;
var buttonClick2Sound = null;
var bonusSounds = new Array();
var nextBonusSound = 0;
var highscores = new Array();
var userID = "";
var userIDDisplay = "";
var instanceID = "";

var repaintElements = new Array();
var tick = 0;
var nextID = 0;

var mode = "normal";
var isIpad = false;
var movementStep = 5;
var timerCountStep = 1;
var animationStep = 1;
var isTouch = false;

function run() {
    isTouch = !!('ontouchstart' in window);
    isIpad = navigator.userAgent.match(/iPad/i) != null;

    enableSound = !isIpad;
    //enableSound = true;
    if (isIpad) {
        movementStep = 3;
        timerCountStep = 2;
        animationStep = 2;
    }
    
    var images = new Object();

    gameSurface = document.getElementById("gameSurface");
    
    if (gameSurface.getContext) {
        gameSurfaceContext = gameSurface.getContext('2d');
        if (isTouch) {
            gameSurface.addEventListener('touchstart', touchClick, false);
            document.body.addEventListener('touchstart', function(e) { e.preventDefault(); });
        }
        else {
            gameSurface.addEventListener('mousedown', mouseClick, false);
        }
    }
    else {
        return;
    }

    baseURL = document.getElementById("baseurl").value;
    instanceID = document.getElementById("instanceid").value;
    assetsPath = baseURL + "documents/html5/games/jewel/";
    imageManager.baseURL = assetsPath;

    if (enableSound) {
        buttonClickSound = new Audio(assetsPath + "click1.mp3");
        buttonClick2Sound = new Audio(assetsPath + "click2.mp3");

        bonusSounds.push(new Audio(assetsPath + "bonus1.mp3"));
        bonusSounds.push(new Audio(assetsPath + "bonus1.mp3"));
        bonusSounds.push(new Audio(assetsPath + "bonus1.mp3"));
        bonusSounds.push(new Audio(assetsPath + "bonus1.mp3"));
        bonusSounds.push(new Audio(assetsPath + "bonus1.mp3"));
    }
    
    addImageSet(images, "back1", 1);
    addImageSet(images, "f", 1);
    addImageSet(images, "r", 1);
    addImageSet(images, "u", 1);
    addImageSet(images, "i", 1);
    addImageSet(images, "t", 1);
    addImageSet(images, "5", 1);
    addImageSet(images, "cloud1", 1);
    addImageSet(images, "cloud2", 1);
    addImageSet(images, "timeCover", 1);
    addImageSet(images, "startGame", 1);
    addImageSet(images, "moreGames", 1);
    addImageSet(images, "pauseMenu", 1);
    addImageSet(images, "continue2", 1);
    addImageSet(images, "practice", 1);
    addImageSet(images, "quit", 1);
    addImageSet(images, "go", 1);
    addImageSet(images, "continue", 1);
    addImageSet(images, "selected", 1);
    addImageSet(images, "1/1", 1);
    addImageSet(images, "1/2", 1);
    addImageSet(images, "1/3", 1);
    addImageSet(images, "1/4", 1);
    addImageSet(images, "1/5", 1);

    imageManager.load(images);
    map.setup();

    setInterval(loop, 33);

    try {
        $.get(baseURL + 'App_CMS/services/Game.aspx?fh=1&gid=' + pageID, function(xml, status) {
            readHighscores(xml);
        }, 'html');
    }
    catch (ex) {

    }

    userID = document.getElementById("hidun").value;
    userIDDisplay = userID;

    if (userID == "") {
        userIDDisplay = "Guest";
    }
}

function recordHighscore() {
    //return;
    if (userID != "" && scoreTotal > 0 && mode != "practice") {
        var tempScore = scoreTotal;
        var key = Math.floor((scoreTotal * (userID.length * 5)) / 8);
        var url = baseURL + 'App_CMS/services/Game.aspx?ph=1&gid=' + pageID + '&u=' + encodeURIComponent(userID) + '&s=' + tempScore + "&k=" + key;

        $.get(url, function(xml, status) {
            readHighscores(xml);
        }, 'html');
    }
}

function recordGamePlay() {
    //return;
    var hostType = "Web";

    if (isIpad) {
        hostType = "iPad";
    }

    var url = baseURL + 'App_CMS/services/Game.aspx?rg=1&gid=' + pageID + '&u=' + encodeURIComponent(userID) + '&i=' + encodeURIComponent(hostType + "-" + instanceID);

    $.get(url, function(xml, status) {
    }, 'html');
}

function readHighscores(xml) {
    highscores = new Array();

    $(xml).find('s').each(function() {
        var highscore = new Highscore();

        highscore.user = $(this).attr('user');
        highscore.score = $(this).attr('score');
        highscores.push(highscore);
    });

    drawnFrontWhole = false;
}

var canvasData = null;

function loop() {
    var i;
    
    if (imageManager.loaded) {
        if (selectedMarker == null) {
            selectedMarker = new GameVisual();
            selectedMarker.load("selected", 1, 1);
            selectedMarker.isVisible = false;

            background = new GameVisual();
            background.load("back1", 1, 1);

            startGameImage = new GameButton();
            startGameImage.load("startGame", 1, 1);

            moreGamesImage = new GameButton();
            moreGamesImage.load("moreGames", 1, 1);

            pauseMenuImage = new GameButton();
            pauseMenuImage.load("pauseMenu", 1, 1);

            quitImage = new GameButton();
            quitImage.load("quit", 1, 1);

            continue2Image = new GameButton();
            continue2Image.load("continue2", 1, 1);

            practiceImage = new GameButton();
            practiceImage.load("practice", 1, 1);

            logoJ = new LogoLetter();
            logoJ.load("f", 1, 1);
            logoJ.offset = -10;
            logoE1 = new LogoLetter();
            logoE1.load("r", 1, 1);
            logoE1.offset = 30;
            logoW = new LogoLetter();
            logoW.load("u", 1, 1);
            logoW.offset = 5;
            logoE2 = new LogoLetter();
            logoE2.load("i", 1, 1);
            logoE2.offset = 20;
            logoL = new LogoLetter();
            logoL.load("t", 1, 1);
            logoL.offset = -5;
            logo5 = new LogoLetter();
            logo5.load("5", 1, 1);
            logo5.offset = 15;

            cloud1 = new Cloud();
            cloud1.load("cloud1", 1, 1);
            cloud1.setY(40);
            cloud1.setX(0);
            cloud1.lastDrawnY = 40;
            cloud1.lastDrawnX = 0;
            cloud2 = new Cloud();
            cloud2.load("cloud2", 1, 1);
            cloud2.lastDrawnY = 15;
            cloud2.setY(15);
            cloud2.lastDrawnX = 450;
            cloud2.setX(450);

            timeCover = new GameVisual();
            timeCover.load("timeCover", 1, 1);

            gameOverImage = new GameVisual();
            gameOverImage.load("go", 1, 1);

            continueImage = new GameButton();
            continueImage.load("continue", 1, 1);
        }

        if (inGame) {
            drawBackground();
            repaintElements = new Array();

            if (!isGameOver && !isPaused) {
                try {
                    for (i = objects.length - 1; i >= 0; i--) {
                        element = objects[i];

                        if (element.isVisible) {
                            element.lastDrawnX = element.x + topleftOffset;
                            element.lastDrawnY = element.y + topleftOffset;

                            element.update();

                            if (element.redraw > 0) {
                                repaintElements.push(element);
                            }
                        }
                    }
                }
                catch (ex) {
                    writeTrace("Object rendering exception: " + ex.description);
                }
                
                if (selectedMarker.isVisible) {
                    selectedMarker.render(gameSurfaceContext);
                }

                if (mode == "normal") {
                    drawTimer();

                    targetTimer -= timerCountStep;

                    if (gameTimer < targetTimer) {
                        gameTimer += 2;
                        if (gameTimer > targetTimer) {
                            gameTimer = targetTimer;
                        }
                    }
                    else if (gameTimer > targetTimer) {
                        gameTimer--;
                    }
                }
            }
/*
            var x;
            var y;
            var text;

            gameSurfaceContext.fillStyle = '#000000';
            gameSurfaceContext.textBaseline = 'top';

            for (y = map.height - 1; y >= 0; y--) {
            for (x = 0; x < map.width; x++) {
            temp = map.grid[x][y];

                    if (temp != null) {
            text = temp.content.id;
            }
            gameSurfaceContext.clearRect((x * 64) + topleftOffset, ((y - 1) * 64) + topleftOffset, 20, 20);
                    gameSurfaceContext.fillText(text, (x * 64) + topleftOffset, ((y - 1) * 64) + topleftOffset);
            }
        }

        gameSurfaceContext.fillStyle = '#ff0000';

        for (y = 0; y < objects.length; y++) {
            text = objects[y].redraw;
            gameSurfaceContext.fillText(text, (objects[y].getGridX() * 64) + topleftOffset, ((objects[y].getGridY() - 1) * 64) + topleftOffset + 10);
        }*/

            if (gameTimer <= 0 && !isGameOver) {
                gameOverScreenAlpha = 10;
                isGameOver = true;
                recordHighscore();
                drawTimer();
            }

            if (isGameOver) {
                drawGameOver();
            }
        }
        else {
            drawBackground();
            drawHighscores();
            drawLogin();

            if (!drawnFrontWhole) {
                startGameImage.setX(gameWidth - (startGameImage.width + 16));
                startGameImage.setY(365);
                startGameImage.render(gameSurfaceContext);

                practiceImage.setX(gameWidth - (practiceImage.width + 16));
                practiceImage.setY(435);
                practiceImage.render(gameSurfaceContext);

                moreGamesImage.setX(18);
                moreGamesImage.setY(395);
                moreGamesImage.render(gameSurfaceContext);
            }

            logoJ.setX(67);
            logoJ.baseY = 118;
            logoJ.render(gameSurfaceContext);
            logoJ.update();

            logoE1.setX(177);
            logoE1.baseY = 110;
            logoE1.render(gameSurfaceContext);
            logoE1.update();

            logoW.setX(271);
            logoW.baseY = 100;
            logoW.render(gameSurfaceContext);
            logoW.update();

            logoE2.setX(375);
            logoE2.baseY = 98;
            logoE2.render(gameSurfaceContext);
            logoE2.update();

            logoL.setX(420);
            logoL.baseY = 102;
            logoL.render(gameSurfaceContext);
            logoL.update();

            logo5.setX(510);
            logo5.baseY = 112;
            logo5.render(gameSurfaceContext);
            logo5.update();
        }

        drawnFrontWhole = true;
    }
    else {
        var totalLoaded = imageManager.loadedCount + 1;
        var toLoad = imageManager.toLoadCount;
        var percent = (totalLoaded / toLoad) * 100;

        gameSurfaceContext.fillStyle = "rgb(0,0,0)";
        gameSurfaceContext.fillRect(0, 0, gameWidth, gameHeight);

        gameSurfaceContext.save();
        gameSurfaceContext.strokeStyle = '#ffffff';

        var text = "Loading please wait... " + Math.round(percent) + "%";
        var textSize = get_textWidth(text, 25);

        gameSurfaceContext.strokeText(text, (gameWidth - textSize) * 0.5, 250, 25);
        //gameSurfaceContext.fillText(text, (gameWidth - textSize.width) * 0.5, 250);

        gameSurfaceContext.restore();
    }

    tick++;
}

var drawnFrontWhole = false;
var debugText = "";

function drawDebug() {
    redrawBackground(150, 2, 250, 31);
    gameSurfaceContext.strokeStyle = '#ffffff';
    gameSurfaceContext.strokeText(debugText + "", 151, 2, 16);
}

function drawScore() {
    redrawBackground(670 - 131, 15, 131, 31);
    gameSurfaceContext.save();

    gameSurfaceContext.strokeStyle = '#ffffff';
    gameSurfaceContext.shadowOffsetX = 2;
    gameSurfaceContext.shadowOffsetY = 2;
    gameSurfaceContext.shadowBlur = 4;
    gameSurfaceContext.shadowColor = "#444444";
    gameSurfaceContext.strokeText(pad(scoreTotal, 7), 670 - 130, 15, 21);

    gameSurfaceContext.restore();
}

function drawBackground() {
    var i;
    var a = 0;
    var y = 0;
    var x;

    if (!drawnFrontWhole) {
        //gameSurfaceContext.clearRect(0, 0, 670, 542);
        background.render(gameSurfaceContext);
        if (inGame) {
            drawScore();

            if (mode == "normal") {
                timeCover.setX(599);
                timeCover.setY(59);
                timeCover.render(gameSurfaceContext);
            }

            pauseMenuImage.setX(gameWidth - (pauseMenuImage.width + 6));
            pauseMenuImage.setY(gameHeight - (pauseMenuImage.height + 12));
            pauseMenuImage.render(gameSurfaceContext);
        }
    }
    else if (inGame) {
        for (i = 0; i < repaintElements.length; i++) {
            redrawBackground(repaintElements[i].lastDrawnX - 1, repaintElements[i].lastDrawnY - 1, repaintElements[i].width + 2, repaintElements[i].height + 2);
        }

        gameSurfaceContext.save();
        gameSurfaceContext.beginPath();
        gameSurfaceContext.rect(topleftOffset, topleftOffset, 542 - topleftOffset, 542 - topleftOffset);
        gameSurfaceContext.clip();

        for (i = 0; i < repaintElements.length; i++) {
            if (repaintElements[i].isVisible) {
                repaintElements[i].render(gameSurfaceContext);
            }
            repaintElements[i].redraw--;
        }

        gameSurfaceContext.restore();
    }
    else {
        redrawBackground(logo5.lastDrawnX, logo5.lastDrawnY, logo5.width, logo5.height);
        redrawBackground(logoE1.lastDrawnX, logoE1.lastDrawnY, logoE1.width, logoE1.height);
        redrawBackground(logoE2.lastDrawnX, logoE2.lastDrawnY, logoE2.width, logoE2.height);
        redrawBackground(logoJ.lastDrawnX, logoJ.lastDrawnY, logoJ.width, logoJ.height);
        redrawBackground(logoW.lastDrawnX, logoW.lastDrawnY, logoW.width, logoW.height);
        redrawBackground(logoL.lastDrawnX, logoL.lastDrawnY, logoL.width, logoL.height);
                
        cloud2.render(gameSurfaceContext);
        cloud2.update();
        cloud1.render(gameSurfaceContext);
        cloud1.update();
    }
}

function redrawBackground(x, y, width, height) {
    if (y < 0) {
        y = 0;
    }
    if (x < 0) {
        x = 0;
    }
    if (x >= gameWidth) {
        return;
    }
    if (x + width >= gameWidth) {
        width = gameWidth - x;
    }

    y = Math.floor(y);
    x = Math.floor(x);

    //gameSurfaceContext.clearRect(x, y, width, height);
    gameSurfaceContext.drawImage(background.frames[background.currentFrame], x, y, width, height, x, y, width, height);

    /*switch (colVar) {
        case 0:
            gameSurfaceContext.fillStyle = "rgb(255,0,0)";
            break;
        case 1:
            gameSurfaceContext.fillStyle = "rgb(255,255,0)";
            break;
        case 2:
            gameSurfaceContext.fillStyle = "rgb(255,0,255)";
            break;
        case 3:
            gameSurfaceContext.fillStyle = "rgb(0,0,255)";
            break;
        case 4:
            gameSurfaceContext.fillStyle = "rgb(0,255,255)";
            break;
        case 5:
            gameSurfaceContext.fillStyle = "rgb(255,255,255)";
            break;
        default:
            gameSurfaceContext.fillStyle = "rgb(0,255,0)";
            break;
    }

    gameSurfaceContext.fillRect(x, y, width, height);

    colVar++;
    if (colVar >= 7) {
        colVar = 0;
    }*/
}

var colVar = 0;

function drawLogin() {
    if (!drawnFrontWhole) {
        gameSurfaceContext.save();
        //gameSurfaceContext.font = '15px arial,sans-serif';
        gameSurfaceContext.strokeStyle = '#ffffff';

        gameSurfaceContext.shadowOffsetX = 1;
        gameSurfaceContext.shadowOffsetY = 1;
        gameSurfaceContext.shadowBlur = 2;
        gameSurfaceContext.shadowColor = "#444444";

        var text = "Logged in as: " + userIDDisplay;
        var textSize = get_textWidth(text, 13);

        gameSurfaceContext.strokeText(text, (gameWidth - textSize) - 8, gameHeight - 24, 13);

        var text = "www.snappygames.com";

        gameSurfaceContext.strokeText(text, 8, gameHeight - 24, 13);

        gameSurfaceContext.restore();
    }
}

function drawHighscores() {
    if (drawnFrontWhole) {
        return;
    }
    
    var i;
    var text;
    var y = 334;
    var x = 226;

    gameSurfaceContext.globalAlpha = 0.3;
    gameSurfaceContext.fillStyle = "rgb(0,0,0)";
    gameSurfaceContext.fillRect(x - 8, y - 8, 235, 176);

    gameSurfaceContext.globalAlpha = 1;

    gameSurfaceContext.save();

    for (i = 0; i < 10; i++) {
        if (highscores[i].user == userID) {
            gameSurfaceContext.strokeStyle = '#ffff00';
        }
        else {
            gameSurfaceContext.strokeStyle = '#ffffff';
        }

        var text = (i + 1) + "";
        var textSize = get_textWidth(text, 11);

        gameSurfaceContext.strokeText(text, x + ((20 - textSize) * 0.5), y, 12);
        gameSurfaceContext.strokeText(highscores[i].user, x + 30, y, 12);
        gameSurfaceContext.strokeText(pad(highscores[i].score, 7), x + 150, y, 12);
        
        y += 16;
    }

    gameSurfaceContext.restore();
}

function playClickSound() {
    if (enableSound) {
        buttonClick2Sound.load();
        buttonClick2Sound.play();
    }
}

function playBonusSound() {
    if (enableSound) {
        bonusSounds[nextBonusSound].load();
        bonusSounds[nextBonusSound].play();

        nextBonusSound++;
        if (nextBonusSound >= bonusSounds.length) {
            nextBonusSound = 0;
        }
    }
}

function playSound(name) {
    var snd = new Audio(assetsPath + name);
    snd.play();
}

var gameOverScreenAlpha = 0;

function drawGameOver() {
    gameOverScreenAlpha -= 1;
    if (gameOverScreenAlpha == 0) {
        gameOverImage.setX(52);
        gameOverImage.setY(40);
        gameOverImage.setOpacity(1);
        gameOverImage.render(gameSurfaceContext);

        continueImage.setX(190);
        continueImage.setY(350);
        continueImage.setOpacity(1);
        continueImage.render(gameSurfaceContext);

        gameSurfaceContext.save();

        gameSurfaceContext.strokeStyle = '#ffffff';
        gameSurfaceContext.shadowOffsetX = 2;
        gameSurfaceContext.shadowOffsetY = 2;
        gameSurfaceContext.shadowBlur = 4;
        gameSurfaceContext.shadowColor = "#444444";

        var text;
        var textSize;

        if (mode == "practice") {
            text = "Thanks for playing!";
        }
        else {
            if (userID != "") {
                text = "Your highscore has been submitted, thanks for playing!";
            }
            else {
                text = "Please login to save you highscores, thanks for playing!";
            }
        }

        textSize = get_textWidth(text, 16);
        gameSurfaceContext.strokeText(text, (gameWidth - textSize) * 0.5, 250, 16);

        gameSurfaceContext.restore();
    }
    else if(gameOverScreenAlpha > 0) {
        gameSurfaceContext.globalAlpha = 0.05;
        gameSurfaceContext.fillStyle = "#000000";
        gameSurfaceContext.fillRect(0, 0, 670, 542);
    }
}

function drawTimer() {
    gameSurfaceContext.globalAlpha = 1;
    var h = (gameTimer / baseTimer) * 400;
    var bH = Math.ceil(400 - h);

    if (h < 0) {
        h = 0;
    }
    if (bH <= 0) {
        bH = 1;
    }

    redrawBackground(600, 60, 16, bH);

    gameSurfaceContext.globalAlpha = 0.3;
    gameSurfaceContext.fillStyle = "#000000";
    gameSurfaceContext.fillRect(600, 60, 16, bH);

    gameSurfaceContext.globalAlpha = 1;
    
    var gradient = gameSurfaceContext.createLinearGradient(600, 0, 616, 0);
    gradient.addColorStop(0, "#D0D000");
    gradient.addColorStop(1, "#D08E00");
    gameSurfaceContext.fillStyle = gradient;
    gameSurfaceContext.fillRect(600, 60 + (400-h), 16, h);
}

function continueGame() {
    isPaused = false;
    drawnFrontWhole = false;

    var i;

    for (i = 0; i < objects.length; i++) {
        objects[i].redraw = 1;
    }
}

function gotoMenuScreen() {
    isPaused = true;

    gameSurfaceContext.globalAlpha = 0.99;
    gameSurfaceContext.fillStyle = "#000000";
    gameSurfaceContext.fillRect(0, 0, gameWidth, gameHeight);

    continue2Image.setX((gameWidth - continue2Image.width) * 0.5);
    continue2Image.setY(170);
    continue2Image.render(gameSurfaceContext);

    quitImage.setX((gameWidth - quitImage.width) * 0.5);
    quitImage.setY(260);
    quitImage.render(gameSurfaceContext);
}

function gotoStartScreen() {
    inGame = false;
    isGameOver = false;
    isPaused = false;
    drawnFrontWhole = false;

    objects = new Array();
    showAd();
}

function startGame(m) {
    mode = m;
    hideAd();
    
    recordGamePlay();
    
    objects = new Array();
    overlay = new Array();

    selected = null;
    selectedY = 0;
    selectedX = 0;
    switching = new Array();
    switchingComplete = new Array();
    toDelete = new Array();
    currentFalling = new Array();
    lastFallList = new Array();
    finishedTimer = 0;
    scoreTotal = 0;

    inGame = true;
    isGameOver = false;
    isPaused = false;
    drawnFrontWhole = false;

    gameTimer = baseTimer;
    targetTimer = baseTimer;
    populate();
}

function addImageSet(images, baseName, count) {
    var i;
    var tmp;

    for (i = 1; i <= count; i++) {
        tmp = baseName + "_" + i;

        images[tmp] = tmp + ".png";
    }
}

function populate() {
    var a;
    var i;
    var piece;
    var loop;
    
    for (a = 0; a < map.height; a++) {
        for (i = 0; i < map.width; i++) {
            loop = true;

            while (loop) {
                piece = createRandomPiece(i, a);
                if (getMatches(piece, 0).length == 0) {
                    objects.push(piece);
                    loop = false;
                }
            }
        }
    }
}

function createRandomPiece(x, y) {
    var no = GetRandomNumber(5) + 1;
    var piece = new BoardPiece();
    var cell = new CellContent();
    var img = "1/" + no;

    piece.load(img, 1, 1);
    piece.type = no;
    piece.setGridX(x);
    piece.setGridY(y);
    piece.repeat = true;
    piece.redraw = 1;
    piece.lastDrawnX = piece.x + topleftOffset;
    piece.lastDrawnY = piece.y + topleftOffset;
    piece.id = nextID;

    nextID++;

    cell.type = 1;
    cell.content = piece;

    map.set(x, y, cell);

    return piece;
}

function clearSelected() {
    var cell = map.get(selectedX, selectedY);

    if (cell != null && cell.content != null) {
        redrawBackground((cell.content.x + topleftOffset) - 1, (cell.content.y + topleftOffset) - 1, cell.content.width + 2, cell.content.height + 2);
        cell.content.render(gameSurfaceContext);
    }
    
    selected = null;
    selectedMarker.isVisible = false;
}

function boardClicked(x, y) {
    if (isGameOver || isPaused) {
        return;
    }
    
    var gridX = Math.floor(x / map.cellWidth);
    var gridY = Math.floor(y / map.cellHeight) + 1;
    var thisCell = map.get(gridX, gridY);

    if (thisCell.content == null && thisCell.type == 0) {
        return;
    }

    if (selected == null) {
        selectedMarker.isVisible = true;
        selectedMarker.setX(thisCell.content.x + topleftOffset);
        selectedMarker.setY(thisCell.content.y + topleftOffset);

        selected = thisCell.content;
        selectedX = gridX;
        selectedY = gridY;
    }
    else {
        if (((gridY == selectedY - 1 || gridY == selectedY + 1) && gridX == selectedX) || ((gridX == selectedX - 1 || gridX == selectedX + 1) && gridY == selectedY)) {
            // Swap
            switchingComplete = new Array();
            switching = new Array();
            switching.push(selected);
            switching.push(thisCell.content);

            selected.swapBegin(gridX, gridY);
            thisCell.content.swapBegin(selected.getGridX(), selected.getGridY());
        }
        else {   // Select new Cell
            if (gridX != selectedX && gridY != selectedY) {
                clearSelected();
                boardClicked(x, y);
            }
            else {
                clearSelected();
            }
        }
    }
    // alert(thisCell.content.getGridX() + "," + thisCell.content.getGridY());
}

function updateFallingPieces()
{
    var temp;
    var x;
    var y;

    currentFalling = new Array();

    for (y = map.height - 2; y >= 0; y--)
    {
        for (x = 0; x < map.width; x++)
        {
            if (map.grid[x][y + 1].type == 0)
            {
                temp = map.grid[x][y];
                if (temp.content != null) {
                    currentFalling.push(temp.content);                    
                    temp.content.fall();

                    temp.type = 0;
                    temp.content = null;
                }
            }
        }
    }

    updateHiddenRow();

    if (currentFalling.length == 0)
    {
        updateMatches(lastFallList, false);
        lastFallList = new Array();
    }
    else
    {
        if (finishedTimer > 0)
        {
            finishedTimer = defaultTimeout;
        }
    }
}

function updateHiddenRow()
{
    var i;
    var piece;
    var loop = true;

    for (i = 0; i < map.width; i++)
    {
        if (map.grid[i][0].type == 0)
        {
            loop = true;

            while (loop)
            {
                piece = createRandomPiece(i, 0);
                if (getMatches(piece, 0).length == 0)
                {
                    objects.push(piece);
                    loop = false;
                }
                else
                {
                }
            }
        }
    }
}

function updateMatches(changes, swapping)
{
    var minX;
    var maxX;
    var minY;
    var maxY;
    var i;
    var matches = getMatches2(changes, 1);

    if (matches.length > 0) {
        if (finishedTimer > 0)
        {
            finishedTimer = defaultTimeout;
        }

        minX = matches[0].x + 32;
        maxX = matches[0].x + 32;
        minY = matches[0].y + 32;
        maxY = matches[0].y + 32;

        clearSelected();

        for (i = 0; i < matches.length; i++) {
            toDelete.push(matches[i]);
            matches[i].matched();

            if (matches[i].x + 32 < minX)
            {
                minX = matches[i].x + 32;
            }
            if (matches[i].x + 32 > maxX)
            {
                maxX = matches[i].x + 32;
            }

            if (matches[i].y + 32 < minY)
            {
                minY = matches[i].y + 32;
            }
            if (matches[i].y + 32 > maxY)
            {
                maxY = matches[i].y + 32;
            }
        }

        var score = matchValue * matches.length;

        switch (matches.length)
        {
            case 3:
                incTimer(20);
                break;
            case 4:
                incTimer(30);
                score += 200;
                break;
            case 5:
                incTimer(40);
                score += 500;
                break;
            case 6:
                incTimer(70);
                score += 1000;
                break;
            default:
                incTimer(100);
                score += 1500;
                break;
        }
        playBonusSound();
        incScore(score);

        /*Bonus bonus = new Bonus(score, 20);
        bonus.x = (minX + ((maxX - minX) * 0.5)) - (bonus.TextWidth * 0.5);
        bonus.y = (minY + ((maxY - minY) * 0.5)) - (bonus.TextHeight * 0.5);

        bonus.RemoveElement += bonus_RemoveElement;
        _pieces.Children.Add(bonus);*/
    }
    else
    {
        if (swapping)
        {
            for (i = 0; i < changes.length; i++) {
                changes[i].cancelSwapBegin(changes[i].swapStartGridX, changes[i].swapStartGridY);
            }
        }
    }
    
    if(matches.length > 0) {
        return true;
    }
    else {
        return false;
    }
}

function incScore(value) {
    scoreTotal += value;

    drawScore();
}

function incTimer(value) {
    if (isIpad) {
        value *= 2;
    }
    
    targetTimer += value;
    if (targetTimer > baseTimer) {
        targetTimer = baseTimer;
    }
}

function getMatches(piece, lowY) {
    var pieces = new Array();

    pieces.push(piece);

    return getMatches2(pieces, lowY);
}

function getMatches2(changes, lowY) {
    var matches = new Array();
    var i;

    for(i=0; i<changes.length; i++) {
        getMatches3(matches, changes[i].getGridX(), changes[i].getGridY(), lowY);
    }

    return matches;
}

function getMatches3(matches, gridX, gridY, lowY) {
    var results = new Array();

    matchInDirection(matches, gridX, gridY, 1, 0, lowY);
    matchInDirection(matches, gridX, gridY, 0, 1, lowY);
}

function matchInDirection(matches, startX, startY, dirX, dirY, lowY) {
    var matchesThisLine = new Array();
    var x = startX;
    var y = startY;
    var loop = true;
    var start = map.get(startX, startY);
    var temp;
    var negDirX = -dirX;
    var negDirY = -dirY;
    var tX = x;
    var tY = y;
    var i;

    if (start.content == null)
    {
        return;
    }

    while (loop)
    {
        temp = map.get(x, y);
        if (temp.content != null)
        {
            if (start.content.type != temp.content.type)
            {
                break;
            }
            else
            {
                tX = x;
                tY = y;
                x += negDirX;
                y += negDirY;

                if (y < lowY)
                {
                    break;
                }
            }
        }
        else
        {
            break;
        }
    }

    x = tX;
    y = tY;

    while (loop)
    {
        temp = map.get(x, y);
        if (temp != null && temp.content != null)
        {
            if (start.content.type == temp.content.type)
            {
                if (!ArrayContains(matchesThisLine, temp.content))
                {
                    matchesThisLine.push(temp.content);
                }
            }
            else
            {
                loop = false;
            }
        }
        else
        {
            loop = false;
        }

        x += dirX;
        y += dirY;

        if (y <= 0)
        {
            loop = false;
        }
    }

    if (matchesThisLine.length > 2)
    {
        for(i=0; i<matchesThisLine.length; i++) {
            if (!ArrayContains(matches, matchesThisLine[i])) {
                matches.push(matchesThisLine[i]);
            }
        }
    }
}

/* Event Handlers */
function touchClick(ev) {
    var touch = ev.touches[0];

    handleClick(touch.pageX, touch.pageY);
}

function mouseClick(ev) {
    var x = ev.clientX;
    var y = ev.clientY;
    var scrollY = f_scrollTop() * 1;
    var scrollX = f_scrollLeft() * 1;

    y += scrollY;
    x += scrollX;

    handleClick(x, y);
}

function handleClick(x, y) {
    var curleft = 0;
    var curtop = 0;
    var obj = gameSurface;

    if (obj.offsetParent) {
        do {
            curleft += obj.offsetLeft;
            curtop += obj.offsetTop;
        } while (obj = obj.offsetParent);
    }

    x -= curleft;
    y -= curtop;

    if (inGame && !isGameOver && !isPaused) {
        boardClicked(x - topleftOffset, y - topleftOffset);
        if (pauseMenuImage.hitTest(x, y)) {
            playClickSound();
            gotoMenuScreen();
        }
    }
    else if (isGameOver) {
        if (continueImage.hitTest(x, y)) {
            playClickSound();
            gotoStartScreen();
        }
    }
    else if (isPaused) {
        if (quitImage.hitTest(x, y)) {
            playClickSound();
            gotoStartScreen();
        }
        else if (continue2Image.hitTest(x, y)) {
            playClickSound();
            continueGame();
        }
    }
    else {
        if (startGameImage.hitTest(x, y)) {
            playClickSound();
            startGame("normal");
        }
        else if (practiceImage.hitTest(x, y)) {
            playClickSound();
            startGame("practice");
        }
        else if (moreGamesImage.hitTest(x, y)) {
            playClickSound();
            window.location = "http://www.snappygames.com/";
        }

        checkClickLetter(logoJ, x, y);
        checkClickLetter(logoE1, x, y);
        checkClickLetter(logoW, x, y);
        checkClickLetter(logoE2, x, y);
        checkClickLetter(logoL, x, y);
        checkClickLetter(logo5, x, y);
    }
}

function checkClickLetter(letter, x, y) {
    if (letter.hitTest(x, y)) {
        letter.jumpHigh();
    }
}

function showAd() {
    document.getElementById('mainAd').style.top = "0px";
}

function hideAd() {
    document.getElementById('mainAd').style.top = "-100px";
}

function f_scrollLeft() {
    return window.pageXOffset;
    /*return f_filterResults(
		window.pageXOffset ? window.pageXOffset : 0,
		document.documentElement ? document.documentElement.scrollLeft : 0,
		document.body ? document.body.scrollLeft : 0
	);*/
}

function f_scrollTop() {
    return window.pageYOffset;
    /*return f_filterResults(
		window.pageYOffset ? window.pageYOffset : 0,
		document.documentElement ? document.documentElement.scrollTop : 0,
		document.body ? document.body.scrollTop : 0
	);*/
}

function f_filterResults(n_win, n_docel, n_body) {
    var n_result = n_win ? n_win : 0;
    if (n_docel && (!n_result || (n_result > n_docel)))
        n_result = n_docel;
    return n_body && (!n_result || (n_result > n_body)) ? n_body : n_result;
}

function BoardPiece_RemoveElement(source) {
    var cellContent = new CellContent();
    cellContent.content = null;
    cellContent.type = 0;

    map.set(source.getGridX(), source.getGridY(), cellContent);
    ArrayRemove(objects, source);

    source.isVisible = false;

    var i = ArrayIndexOf(toDelete, source);

    if (i >= 0) {
        toDelete.splice(i, 1);

        if (toDelete.length == 0) {
            updateFallingPieces();
        }
    }
}

function GameVisual_Delete(source) {
    var i;

    for (i = overlay.length - 1; i >= 0; i--) {

        if (overlay[i] == source) {
            overlay.splice(i, 1);
            break;
        }
    }
}

function BoardPiece_SwapCompleteCheckMatches(source) {    
    if (!ArrayContains(switchingComplete, source)) {
        var cellContent = new CellContent();

        cellContent.type = 1;
        cellContent.content = source;

        map.set(source.getGridX(), source.getGridY(), cellContent);
        switchingComplete.push(source);
        
        if (switchingComplete.length == switching.length) {
            updateMatches(switchingComplete, true);
        }
    }
}

function BoardPiece_FallComplete(source) {
    var i = ArrayIndexOf(currentFalling, source);
    
    if (i >= 0) {
        var cellContent = new CellContent();
        cellContent.content = source;
        cellContent.type = 1;

        map.set(source.getGridX(), source.getGridY(), cellContent);

        currentFalling.splice(i, 1);
        lastFallList.push(source);

        if (currentFalling.length == 0) {
            updateFallingPieces();
        }
    }
}

function BoardPiece_SwapResetComplete(source) {
    var cellContent = new CellContent();
    cellContent.content = source;
    cellContent.type = 1;

    map.set(source.getGridX(), source.getGridY(), cellContent);

    if (selected == source) {
        clearSelected();
    }
}

/* Useful functions */
function ArrayRemove(array, item) {
    var i = ArrayIndexOf(array, item);
    
    if (i >= 0) {
        array.splice(i, 1);
    }
}

function ArrayContains(array, item) {
    if (ArrayIndexOf(array, item) >= 0) {
        return true;
    }
    else {
        return false;
    }
}

function ArrayIndexOf(array, item) {
    var result = -1;
    var i;

    for (i = 0; i < array.length; i++) {
        if (array[i] == item) {
            result = i;
            break;
        }
    }

    return result;
}

function ArrayIndexOfById(array, id) {
    var result = -1;
    var i;

    for (i = 0; i < array.length; i++) {
        if (array[i].id == id) {
            result = i;
            break;
        }
    }

    return result;
}

function DegToRad(d) {
    return d * 0.0174532925199432957;
}

function GetRandomNumber(max) {
    return Math.floor(Math.random() * max);
}

function pad(number, length) {

    var str = '' + number;
    while (str.length < length) {
        str = '0' + str;
    }

    return str;

}

function clearTrace() {
    //document.getElementById("output").innerHTML = "";
}

function writeTrace(o) {
    //o = tick + ": " + o;
    //document.getElementById("output").innerHTML = document.getElementById("output").innerHTML + o + "<br />";
}

/* Image Manager */
function ImageManager() {
    this.baseURL = assetsPath;
    this.images = {};
    this.toLoadCount = 0;
    this.loadedCount = 0;
    this.loaded = false;

    this.load = function(list) {
        var img;

        for (x in list) {
            this.toLoadCount++;
            
            img = new Image();
            img.onload = this.loadingComplete;
            img.src = this.baseURL + list[x];

            this.images[x] = img;
        }
    }

    this.loadingComplete = function(e) {
        imageManager.loadedCount++;

        if (imageManager.loadedCount == imageManager.toLoadCount) {
            imageManager.loaded = true;
            showAd();
        }
    }
}

/* Game Visual */
function GameVisual() {
    this.id = 0;
    this.frames = new Array();
    this.x = 0;
    this.y = 0;
    this.width = 0;
    this.height = 0;
    this.halfWidth = 0;
    this.halfHeight = 0;
    this.currentFrame = 0;
    this.repeat = false;
    this.isVisible = true;
    this.transformedPoints = new Array();
    this.direction = new Point2();
    this.speed = new Point2();
    this.speedMod = 1;
    this.opacity = 1;
    this.redraw = 1;
    this.lastDrawnX = 0;
    this.lastDrawnY = 0;

    this.setOpacity = function(value) {
        if (value != this.opacity) {
            this.redraw = 2;
        }
        else {
            this.redraw = 0;
        }
        this.opacity = value;
    }
    
    this.setX = function(value) {
        if (value != this.x) {
            this.redraw = 2;
        }
        else {
            this.redraw = 0;
        }
        this.x = value;
    }

    this.setY = function(value) {
        if (value != this.y) {
            this.redraw = 2;
        }
        else {
            this.redraw = 0;
        }
        this.y = value;
    }

    // Getters/Setters
    this.getGridX = function() {
        return Math.round(this.x / map.cellWidth);
    }
    this.setGridX = function(value) {
        this.setX(value * map.cellWidth);
    }
    this.getGridY = function() {
        return Math.round((this.y + map.cellHeight) / map.cellHeight);
    }
    this.setGridY = function(value) {
        this.y = (value * map.cellHeight) - map.cellHeight;
    }
    
    // End Getters/Setters

    this.load = function(baseImage, count, delay) {
        var i, a;
        var tmp;

        for (i = 1; i <= count; i++) {
            tmp = baseImage + "_" + i;

            this.width = imageManager.images[tmp].width;
            this.height = imageManager.images[tmp].height;
            this.halfWidth = this.width * 0.5;
            this.halfHeight = this.height * 0.5;

            for (a = 0; a < delay; a++) {
                this.frames.push(imageManager.images[tmp]);
            }
        }
    }

    this.render = function(context) {
        context.globalAlpha = this.opacity;
        context.drawImage(this.frames[this.currentFrame], this.x, this.y);

        this.lastDrawnX = this.x;
        this.lastDrawnY = this.y;
    }

    this.update = function() {
        this.currentFrame++;
        if (this.currentFrame >= this.frames.length) {
            if (this.repeat) {
                this.currentFrame = 0;
            }
            else {
                this.animationComplete();
            }
        }
    }

    this.animationComplete = function() {
    }

    this.remove = function() {
        this.redraw = 2;
        GameVisual_Delete(this);
    }
    
    this.getCurrentImage = function() {
        return this.frames[this.currentFrame];
    }

    this.hitTest = function(x, y) {
        if (x >= this.x && x < this.x + this.width && y >= this.y && y < this.y + this.height) {
            return true;
        }
        else {
            return false;
        }
    }
}

function ComplexGameVisual() {
    this.inheritFrom = GameVisual;
    this.inheritFrom();
    
    this.rotate = 0;

    this.render = function(context) {
        context.save();
        context.globalAlpha = this.opacity;
        context.translate(this.x + this.halfWidth, this.y + this.halfHeight);
        context.rotate(DegToRad(this.rotate));
        context.translate(-this.halfWidth, -this.halfHeight);
        context.drawImage(this.frames[this.currentFrame], 0, 0);
        context.restore();
    }

    this.baseUpdate = this.update;
    this.update = function() {
        this.baseUpdate();
    }
}

/* Explosion */
function Explosion() {
    this.inheritFrom = GameVisual;
    this.inheritFrom();

    this.animationComplete = function() {
        this.remove();
    }
}

/* Game Button */
function GameButton() {
    this.inheritFrom = GameVisual;
    this.inheritFrom();
    this.opacityDir = -0.02;

    this.update = function() {
        this.setOpacity(this.opacity + this.opacityDir);
        
        if (this.opacity >= 1) {
            this.setOpacity(1);
            this.opacityDir = -this.opacityDir;
        }
        else if (this.opacity <= 0.4) {
            this.setOpacity(0.4);
            this.opacityDir = -this.opacityDir;
        }
    }
}

/* Cloud */
function Cloud() {
    this.inheritFrom = GameVisual;
    this.inheritFrom();
    this.dir = 0.5;

    this.render = function(context) {
        this.lastDrawnX = topleftOffset + this.x;
        this.lastDrawnY = topleftOffset + this.y;

        context.drawImage(this.frames[this.currentFrame], this.lastDrawnX, this.lastDrawnY);
    }

    this.update = function() {
        this.setX(this.x + this.dir);

        if (this.x > gameWidth) {
            this.setX(-this.width);
        }
    }
}

/* Logo Letter */
function LogoLetter() {
    this.inheritFrom = GameVisual;
    this.inheritFrom();

    this.baseY = 0;
    this.offset = 0;
    this.offsetDir = 1;

    this.jumpLow = function() {
        this.offsetDir -= 2;
    }

    this.jumpHigh = function() {
        this.offsetDir -= 8;
    }

    this.render = function(context) {
        this.lastDrawnX = topleftOffset + this.x;
        this.lastDrawnY = topleftOffset + this.y;

        context.drawImage(this.frames[this.currentFrame], this.lastDrawnX, this.lastDrawnY);
    }

    this.update = function() {
        this.y = this.baseY + this.offset;

        if (this.offsetDir < 0) {
            this.offset += (this.offsetDir * animationStep);
            if (this.offsetDir >= 0) {
                this.offsetDir = 1;
            }
        }
        else {
            this.offset += (this.offsetDir * animationStep);
        }

        if (this.offset >= 80) {
            this.offset = 80;
            this.offsetDir = -this.offsetDir;

            if (GetRandomNumber(10) > 5) {
                this.jumpLow();
            }
        }

        if (this.offsetDir < 0) {
            this.offsetDir += 0.75;
            if (this.offsetDir >= -0.5) {
                this.offsetDir = 0.5;
            }
        }
        if (this.offsetDir > 0) {
            this.offsetDir += 0.5;
        }
    }
}

/* Board Piece */
function BoardPiece() {
    this.inheritFrom = GameVisual;
    this.inheritFrom();

    // Private Properties
    this.targetStepX = 0;
    this.targetStepY = 0;
    this.targetSteps = 0;
    this.swapStart = false;
    this.falling = false;

    // Public Properties
    this.type = 0;
    this.useTarget = false;
    this.targetX = 0;
    this.targetY = 0;
    this.swapStartGridX = 0;
    this.swapStartGridY = 0;
    this.isMatched = false;

    this.render = function(context) {
        this.lastDrawnX = topleftOffset + this.x;
        this.lastDrawnY = topleftOffset + this.y;

        context.globalAlpha = this.opacity;
        context.drawImage(this.frames[this.currentFrame], this.lastDrawnX, this.lastDrawnY);
    }

    this.swapBegin = function(gridX, gridY) {
        this.swapStart = true;
        this.swapStartGridX = this.getGridX();
        this.swapStartGridY = this.getGridY();

        this.moveTo(gridX * map.cellWidth, (gridY - 1) * map.cellHeight, movementStep);
    }

    this.cancelSwapBegin = function(gridX, gridY) {
        this.swapStart = false;
        this.moveTo(gridX * map.cellWidth, (gridY - 1) * map.cellHeight, movementStep);
    }

    this.fall = function() {
        this.falling = true;
        this.moveTo(this.getGridX() * map.cellWidth, this.getGridY() * map.cellHeight, movementStep);
    }

    this.moveTo = function(tx, ty, steps) {
        this.useTarget = true;
        this.targetX = tx;
        this.targetY = ty;

        this.targetSteps = steps;
        this.targetStepX = (this.targetX - this.x) / this.targetSteps;
        this.targetStepY = (this.targetY - this.y) / this.targetSteps;
    }

    this.matched = function() {
        if (!this.isMatched) {
            this.isMatched = true;
        }
    }
    
    this.baseUpdate = this.update;
    this.update = function() {
        this.baseUpdate();

        if (this.useTarget) {
            this.x += this.targetStepX;
            this.y += this.targetStepY;

            this.targetSteps--;

            if (this.targetSteps <= 0) {
                this.useTarget = false;
                x = this.targetX;
                y = this.targetY;

                if (this.swapStart) {
                    this.swapStart = false;
                    BoardPiece_SwapCompleteCheckMatches(this);
                }
                else if (this.falling) {
                    this.falling = false;
                    BoardPiece_FallComplete(this);
                }
                else {
                    BoardPiece_SwapResetComplete(this);
                }
            }

            this.redraw = 2;
        }
        else {
            if (this.direction.x != 0 || this.direction.y != 0) {
                this.setX(this.x + (this.direction.x * (this.speed.x * this.speedMod)));
                this.setY(this.y + (this.direction.y * (this.speed.y * this.speedMod)));
            }
        }

        if (this.isMatched) {
            this.setOpacity(this.opacity - 0.15);

            if (this.opacity <= 0.2) {
                BoardPiece_RemoveElement(this);
            }
        }
    }
}

/* Highscore Result */
function Highscore() {
    this.user = "";
    this.score = "";
}

/* Path Finding Map */
function PathFindingMap() {
    this.cellWidth = 64;
    this.cellHeight = 64;
    this.width = 8;
    this.height = 9;
    this.grid = null;

    this.setup = function() {
        var i;
        this.grid = new Array(this.width);

        for (i = 0; i < this.width; i++) {
            this.grid[i] = new Array(this.height);
        }
    }

    this.get = function(x, y) {
        if (x < 0 || x >= this.width || y < 0 || y >= this.height) {
            return new CellContent();
        }

        return this.grid[x][y];
    }

    this.set = function(x, y, cellContent) {
        if (x < 0 || x >= this.width || y < 0 || y >= this.height) {
            return;
        }

        this.grid[x][y] = cellContent;
    }
}

/* Point2 */
function Point2() {
    this.x = 0;
    this.y = 0;
}

function Rect() {
    this.x = 0;
    this.y = 0;
    this.width = 0;
    this.height = 0;
}

/* CellContent */
function CellContent() {
    this.type = 0;
    this.content = null;
}
