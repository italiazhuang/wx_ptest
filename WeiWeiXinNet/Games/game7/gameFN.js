function VectorlightGame() {
    this.browser = "";
    this.deviceName = "Web";
    this.pageID = -1;
    this.gameWidth = 320;
    this.gameHeight = 460;
    this.userID = "";
    this.userIDDisplay = "";
    this.instanceID = "";
    this.useTouch = false;
    this.baseURL = "";
    this.rootID = "";
    this.tick = 0;
    this.splashTimer = 60;
    this.splashOpacity = 0;
    this.serviceURL;
    this.loadScrollY = 0;

    this.gameInit = function (rootElementID, gameID, width, height, interval) {
        if (interval < 20) {
            this.splashTimer = 3 * 60;
        }
        else {
            this.splashTimer = 3 * 30;
        }

        if (navigator.userAgent.match(/FireFox/i) != null) {
            this.browser = "FF";
        }
        else {
            switch (navigator.appName) {
                case "Microsoft Internet Explorer":
                    this.browser = "IE";
                    break;
                default:
                    this.browser = "WK";
                    break;
            }
        }

        this.pageID = gameID;
        this.deviceName = this.getDevice();
        this.rootID = rootElementID;

        this.gameWidth = width;
        this.gameHeight = height;

        if (this.deviceName != "Web") {
            this.useTouch = true;
        }

        this.userID = this.dg("hidun").value;
        this.userIDDisplay = this.userID;

        if (this.userID == "") {
            this.userIDDisplay = "Guest";
        }

        this.baseURL = "";
        if (window.location.hostname == "localhost") {
            this.baseURL = "http://localhost/vlx/";
        }
        else {
            this.baseURL = "http://www.vectorlight.net/";
        }
        this.serviceURL = this.baseURL + 'App_CMS/services/Game.aspx';

        setInterval(this.gameTick, interval);
    }

    this.gameTick = function () {
        thisObj = vlx;

        if (thisObj.splashTimer > 0) {
            if (thisObj.useTouch) {
                window.scrollTo(0, thisObj.loadScrollY);
            }
            thisObj.splashTimer--;

            if (thisObj.splashTimer == 0) {
                thisObj.hd("splashContainer");
            }
            else {
                thisObj.dg("loadingProgress").innerHTML = "Loading 100%";
                thisObj.dg("splash").style.opacity = thisObj.splashOpacity;

                thisObj.splashOpacity += 0.05;
                if (thisObj.splashOpacity > 1) {
                    thisObj.splashOpacity = 1;
                    thisObj.sh(thisObj.rootID);
                }
                return;
            }
        }

        gameLoop();
        this.tick++;
    }

    this.pad = function (number, length) {
        var str = '' + number;
        while (str.length < length) {
            str = '0' + str;
        }

        return str;
    }

    this.dce = function (t, c) {
        var a = document.createElement(t);
        a.className = c;
        return a;
    }

    this.dg = function (id) {
        return document.getElementById(id);
    }

    this.hd = function (id) {
        this.dg(id).style.display = "none";
    }

    this.sh = function (id) {
        this.dg(id).style.display = "block";
    }

    this.aTS = function (id, fn) {
        this.dg(id).addEventListener('touchstart', fn, false);
    }

    this.aTE = function (id, fn) {
        this.dg(id).addEventListener('touchend', fn, false);
    }

    this.uIP = function (obj) {
        var xy = (obj.x | 0) + "px," + (obj.y | 0) + "px";

        obj.style.webkitTransform = "translate3d(" + xy + ",0)";
        obj.style.MozTransform = "translate(" + xy + ")";
        obj.style.msTransform = obj.style.MozTransform;
    }

    this.getDevice = function () {
        var deviceName = "Web";

        if (navigator.userAgent.match(/iPad/i) != null) {
            deviceName = "iPad";
        }
        else if (navigator.userAgent.match(/iPod/i) != null) {
            deviceName = "iPod";
        }
        else if (navigator.userAgent.match(/iPhone/i) != null) {
            deviceName = "iPhone";
        }
        else if (navigator.userAgent.match(/Android/i) != null) {
            deviceName = "Android";
        }

        return deviceName;
    }

    this.ArrayRemove = function (array, item) {
        var i = this.ArrayIndexOf(array, item);

        if (i >= 0) {
            array.splice(i, 1);
        }
    }

    this.ArrayContains = function (array, item) {
        if (this.ArrayIndexOf(array, item) >= 0) {
            return true;
        }
        else {
            return false;
        }
    }

    this.ArrayIndexOf = function (array, item) {
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

    this.recordHighscore = function (score, levelNo) {
        try {
            if (this.userID != "" && score > 0) {
                var tempScore = score;
                var key = Math.floor((score * (this.userID.length * 5)) / 8);
                var url = this.serviceURL + '?ph=1&gid=' + this.pageID + '&u=' + encodeURIComponent(this.userID) + '&s=' + score + "&k=" + key + "&l=" + levelNo;

                $.get(url, function (xml, status) {
                    this.readHighscores(xml);
                }, 'html');
            }
        }
        catch (e) {

        }
    }

    this.recordBestTime = function (time, levelNo) {
        //alert(this.userID + " - " + time);

        try {
            if (this.userID != "" && time > 0) {
                var key = Math.floor((time * (this.userID.length * 5)) / 8);
                var url = this.serviceURL + '?pt=1&gid=' + this.pageID + '&u=' + encodeURIComponent(this.userID) + '&s=' + time + "&k=" + key + "&l=" + levelNo;

                $.get(url, function (xml, status) {
                    this.readHighscores(xml);
                }, 'html');
            }
        }
        catch (e) {

        }
    }

    this.recordGamePlay = function () {
        try {
            var hostType = this.deviceName;
            var url = this.serviceURL + '?rg=1&gid=' + this.pageID + '&u=' + encodeURIComponent(this.userID) + '&i=' + encodeURIComponent(hostType + "-" + this.instanceID);

            $.get(url, function (xml, status) {
            }, 'html');
        }
        catch (e) {

        }
    }

    this.readHighscores = function (xml) {
        try {
            highscores = new Array();
            $(xml).find('s').each(function () {
                var highscore = new Highscore($(this).attr('user'), $(this).attr('score'), $(this).attr('level'));

                highscores.push(highscore);
            });

            drawHighscores();
        }
        catch (e) {

        }
    }

    this.readBestLevelHighscores = function (xml) {
        try {
            bestLevelScores = new Array();

            $(xml).find('s').each(function () {
                var highscore = new Highscore($(this).attr('user'), $(this).attr('score'), $(this).attr('level'));

                bestLevelScores[highscore.level] = highscore;
            });
        }
        catch (e) {

        }
    }

    this.readBestUserHighscores = function (xml) {
        try {
            bestUserScores = new Array();

            $(xml).find('s').each(function () {
                var highscore = new Highscore($(this).attr('user'), $(this).attr('score'), $(this).attr('level'));

                bestUserScores[highscore.level] = highscore;
            });
        }
        catch (e) {

        }
    }

    this.saveAchievement = function (id, value) {
    }

    this.getUserId = function () {
        0;
    }

    this.getUsername = function () {
        "Guest";
    }

    this.getBestAchievement = function (taskID, ctrlName, ctrlScore) {
        document.getElementById(ctrlName).innerHTML = "MagicAppStore";
        document.getElementById(ctrlScore).innerHTML = "00000";
    }
}

/* Highscore Result */
function Highscore(user, score, level) {
    this.user = user;
    this.score = score;
    this.level = level;
}