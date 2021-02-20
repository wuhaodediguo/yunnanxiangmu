<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CopyMFRubikCubePowerContent.WebForm1" %>



<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>视频用例</title>
    <link href="../../../bootstrap/css/button.css" type="text/css" rel="stylesheet">
    <link href="../css/video.css" type="text/css" rel="stylesheet">
    <script  type="text/javascript" src="../../js/jquery.min.js?version=7.18.0.1_20191018"></script>
    <script  type="text/javascript" src="jquery.query-2.1.7.js?version=7.18.0.1_20191018"></script>
    <script type="text/javascript" src="../../../js/lhgdialog.min.js?version=7.18.0.1_20191018"></script>
    <script type="text/javascript" src="swfobject.js?version=7.18.0.1_20191018"></script>
    <script type="text/javascript" src="http://code.jquery.com/jquery.min.js"></script>
    <script type="text/javascript" src="http://119.23.22.86:88/808gps/open/player/swfobject.js"></script>
    <script>
        var isInitFinished = false; //视频插件是否加载完成
        var lang = new langZhCn();
        function langZhCn() {
            this.videoExample = "视频用例";
            this.geSessionId = "获取会话号";
            this.userId = "用户名：";
            this.password = "密码：";
            this.login = "登陆";
            this.videoInit = "初始化";
            this.videoLang = "插件语言：";
            this.videoWidth = "插件宽度：";
            this.videoHeight = "插件高度：";
            this.serverIp = "服务器IP：";
            this.serverPort = "端口：";
            this.windowNumber = "窗口数目：";
            this.settings = "设置";
            this.videoLive = "实时视频";
            this.windowIndex = "窗口下标：";
            this.title = "标题：";
            this.jsession = "会话号：";
            this.stream = "码流：";
            this.devIdno = "设备号：";
            this.channel = "通道：";
            this.play = "播放";
            this.stop = "停止";
            this.reset = "重置";
            this.monitor = "监听";
            this.talkback = "对讲";
            this.url = "url链接：";
            this.playback = "远程回放";
            this.nullMic = "您的电脑上没有麦克风，无法启动对讲";
            this.micStop = "没有开启FLASH插件麦克风";
            this.loginError = "登陆失败";
            this.talkback_flashMicStep1 = "第一步，请在视频窗上右键菜单中选择设置";
            this.talkback_flashMicStep2 = "第二步在设置窗口中 选择 “允许”，并勾选“记住”";
            this.talkback_flashMicStep3 = "关闭设置，并重新启动对讲";
            this.bufferTimeDesc = "说明：主要用于调整视频延时，当缓存的数据达到了最小缓冲时长时（默认为2秒），则会进行播放，当到了最大缓冲时长（默认为6秒），则进行快放。";
            this.minBufferTime = "最小缓冲时长：";
            this.maxBufferTime = "最大缓冲时长：";
            this.vedioStatus = "选中窗口播放状态";
            this.vedioEventStart = '选中事件：选中第';
            this.vedioEventEnd = '个窗口';
            this.vedioPlay = "当前选中窗口正在进行视频播放";
            this.vedioNoPlay = "当前选中窗口未进行视频播放";


        }
        function langEn() {
            this.videoExample = "Video Example";
            this.geSessionId = "Get Jsession";
            this.userId = "Account:";
            this.password = "Password:";
            this.login = "Login";
            this.videoInit = "Init";
            this.videoLang = "language:";
            this.videoWidth = "Width:";
            this.videoHeight = "Height:";
            this.serverIp = "ServerIP:";
            this.serverPort = "Port:";
            this.windowNumber = "WindowNum:";
            this.settings = "Setting";
            this.videoLive = "Live Video";
            this.windowIndex = "Index:";
            this.title = "Title:";
            this.jsession = "Jsession:";
            this.stream = "Stream:";
            this.devIdno = "DevIdno:";
            this.channel = "Channel:";
            this.play = "Play";
            this.stop = "Stop";
            this.reset = "Reset";
            this.monitor = "Monitor";
            this.talkback = "Talkback";
            this.url = "url:";
            this.playback = "Playback";
            this.nullMic = "On your computer does not have a microphone, you can not start speaking";
            this.micStop = "FLASH plug-in microphone is not turned on";
            this.loginError = "Login failed";
            this.talkback_flashMicStep1 = "1. select Settings in the video window on the right-click menu";
            this.talkback_flashMicStep2 = "The second step in the Settings window select 'Allow' and check the 'Remember'";
            this.talkback_flashMicStep3 = "Close the settings and restart the intercom";
            this.bufferTimeDesc = "Description:It's mainly used for the adjustment of video lazy load. When the video buffers the minimum buffer time(defaults to 2 seconds) of video,"
     		+ " then it will play the video. When the video buffers the maximum buffer time(defaults to 6 seconds) of video, then it will play the video fast-forward.";
            this.minBufferTime = "Minimun Buffer Time:";
            this.maxBufferTime = "Maximun Buffer Time:";
            this.vedioStatus = "Select window play status";
            this.vedioEventStart = 'Select event: selected  Window ';
            this.vedioEventEnd = ' ';
            this.vedioPlay = "The currently selected window is Playing video now";
            this.vedioNoPlay = "There is no video playback in the current selected window";
        }

        function loadLang() {
            document.title = lang.videoExample;
            $('#getJsessionTitle').text(lang.geSessionId);
            $('#accountTitle').text(lang.userId);
            $('#passwordTitle').text(lang.password);
            $('#userLoginBtn').text(lang.login);
            $('#isPlay').text(lang.vedioStatus);
            $('#videoInitTitle').text(lang.videoInit);
            $('#videoInitBtn').text(lang.videoInit);
            $('#videoLangTitle').text(lang.videoLang);
            $('#videoWidthTitle').text(lang.videoWidth);
            $('#videoHeightTitle').text(lang.videoHeight);
            $('#windowNumberTitle').text(lang.windowNumber);
            $('#videoLiveTitle').text(lang.videoLive);
            $('#videoTitleTitle').text(lang.title);
            $('#videoStreamTitle').text(lang.stream);
            $('#videoPlayBtn').text(lang.play);
            $('#videoResetBtn').text(lang.reset);
            $('#monitorTitle').text(lang.monitor);
            $('#monitorBtn').text(lang.monitor);
            $('#talkbackTitle').text(lang.talkback);
            $('#talkbackBtn').text(lang.talkback);
            $('#playbackTitle').text(lang.playback);
            $('#urlTitle').text(lang.url);
            $('#playbackBtn').text(lang.playback);
            $('#bufferTimeDesc').text(lang.bufferTimeDesc);

            $('.minBufferTimeTitle').text(lang.minBufferTime);
            $('.maxBufferTimeTitle').text(lang.maxBufferTime);
            $('.serverIp').text(lang.serverIp);
            $('.serverPort').text(lang.serverPort);
            $('.settings').text(lang.settings);
            $('.windowIndex').text(lang.windowIndex);
            $('.jsessionId').text(lang.jsession);
            $('.devIdnoTitle').text(lang.devIdno);
            $('.devChannelTitle').text(lang.channel);
            $('.stop').text(lang.stop);
        }

        $(document).ready(function () {
            var host = window.location.host;
            var ip = host.split(":")[0];
            if (!ip || ip == 'localhost') {
                ip = '127.0.0.1';
            }
            $('#serverIp').val(ip);
            $('.monitorServerIp').val(ip);
            $('.talkbackServerIp').val(ip);
            $('#serverPort').val(6605);
            $('.monitorServerPort').val(6605);
            $('.talkbackServerPort').val(6605);

            if ($.query.get("lang") == "en") {
                lang = new langEn();
                $('.languagePath').val('en.xml');
            }
            loadLang();

            //初始化视频插件
            initPlayerExample();
        });

        //初始化视频插件
        function initPlayerExample() {
            for (var i = 0; i < 101; i++) {
                playingStatusArray.push(false);
            }
            //视频参数
            var params = {
                allowFullscreen: "true",
                allowScriptAccess: "always",
                bgcolor: "#FFFFFF",
                wmode: "transparent"
            };
            //赋值初始化为未完成
            isInitFinished = false;
            //视频插件宽度
            var width = $.trim($('.playerWidth').val());
            if (width == '') {
                $('.playerWidth').focus();
                return;
            }
            //视频插件高度
            var hieght = $.trim($('.playerHeight').val());
            if (hieght == '') {
                $('.playerHeight').focus();
                return;
            }
            //初始化flash
            swfobject.embedSWF("player.swf", "cmsv6flash", width, hieght, "11.0.0", null, null, params, null);
            initFlash();
        }
        //插件初始化完成后执行
        function initFlash() {
            if (swfobject.getObjectById("cmsv6flash") == null ||
             	typeof swfobject.getObjectById("cmsv6flash").setWindowNum == "undefined") {
                setTimeout(initFlash, 50);
            } else {
                //初始化插件语言
                var language = $.trim($('.languagePath').val());
                if (!language) {
                    $('.languagePath').focus();
                    return;
                }
                swfobject.getObjectById("cmsv6flash").setLanguage(language);
                //先将全部窗口创建好
                swfobject.getObjectById("cmsv6flash").setWindowNum(36);
                //再配置当前的窗口数目
                var windowNum = $.trim($('.windowNumber').val());
                if (windowNum == '') {
                    $('.windowNumber').focus();
                    return;
                }
                swfobject.getObjectById("cmsv6flash").setWindowNum(windowNum);
                //设置服务器信息
                var serverIp = $.trim($('#serverIp').val());
                if (!serverIp) {
                    $('#serverIp').focus();
                    return;
                }
                var serverPort = $.trim($('#serverPort').val());
                if (!serverPort) {
                    $('#serverPort').focus();
                    return;
                }
                swfobject.getObjectById("cmsv6flash").setServerInfo(serverIp, serverPort);
                isInitFinished = true;
            }
        }

        //设置视频插件窗口数量
        function setVideoWindowNumber() {
            if (!isInitFinished) {
                return;
            } else {
                //窗口数目
                var windowNum = $.trim($('.windowNumber').val());
                if (windowNum == '') {
                    $('.windowNumber').focus();
                    return;
                }
                swfobject.getObjectById("cmsv6flash").setWindowNum(windowNum);
            }
        }

        //设置视频插件服务器信息
        function setVideoServer() {
            if (!isInitFinished) {
                return;
            } else {
                //服务器信息
                var serverIp = $.trim($('#serverIp').val());
                if (!serverIp) {
                    $('#serverIp').focus();
                    return;
                }
                var serverPort = $.trim($('#serverPort').val());
                if (!serverPort) {
                    $('#serverPort').focus();
                    return;
                }
                swfobject.getObjectById("cmsv6flash").setServerInfo(serverIp, serverPort);
            }
        }

        //设置视频插件语言
        function setVideoLanguage() {
            if (!isInitFinished) {
                return;
            } else {
                //语言文件
                var language = $.trim($('.languagePath').val());
                if (!language) {
                    $('.languagePath').focus();
                    return;
                }
                swfobject.getObjectById("cmsv6flash").setLanguage(language);
            }
        }

        //设置窗口标题
        function setWindowTitle() {
            if (!isInitFinished) {
                return;
            } else {
                //窗口下标
                var index = $.trim($('.liveVideoIndex').val());
                if (index == '') {
                    $('.liveVideoIndex').focus();
                    return;
                }
                //标题
                var title = $.trim($('.liveWindowTitle').val());
                swfobject.getObjectById("cmsv6flash").setVideoInfo(index, title);
            }
        }

        //播放实时视频
        function playLiveVideo() {
            if (!isInitFinished) {
                return;
            }
            //窗口下标
            var index = $.trim($('.liveVideoIndex').val());
            if (index == '') {
                $('.liveVideoIndex').focus();
                return;
            }
            //jsession会话号
            var jsession = $.trim($('.liveJsession').val());
            if (jsession == '') {
                $('.liveJsession').focus();
                return;
            }
            //设备号
            var devIdno = $.trim($('.liveDevIdno').val());
            if (devIdno == '') {
                $('.liveDevIdno').focus();
                return;
            }
            //通道号
            var channel = $.trim($('.liveChannel').val());
            if (channel == '') {
                $('.liveChannel').focus();
                return;
            }
            //码流
            var stream = $.trim($('.liveStream').val());
            if (stream == '') {
                $('.liveStream').focus();
                return;
            }
            //最小缓冲时长
            var minBufferTime = $.trim($('.minBufferTime').val());
            if (minBufferTime != '') {
                swfobject.getObjectById("cmsv6flash").setBufferTime(index, minBufferTime);
            }
            //最大缓冲时长
            var maxBufferTime = $.trim($('.maxBufferTime').val());
            if (maxBufferTime != '') {
                swfobject.getObjectById("cmsv6flash").setBufferTimeMax(index, maxBufferTime);
            }

            //先停止视频窗口
            swfobject.getObjectById("cmsv6flash").stopVideo(index);
            //设置窗口标题
            var title = $.trim($('.liveWindowTitle').val());
            swfobject.getObjectById("cmsv6flash").setVideoInfo(index, title);
            //播放视频
            swfobject.getObjectById("cmsv6flash").startVideo(index, jsession, devIdno, channel, stream, true);
        }

        //停止视频窗口播放视频窗口
        function stopLiveVideo() {
            if (!isInitFinished) {
                return;
            } else {
                //窗口下标
                var index = $.trim($('.liveVideoIndex').val());
                if (index == '') {
                    $('.liveVideoIndex').focus();
                    return;
                }
                swfobject.getObjectById("cmsv6flash").stopVideo(index);
            }
        }

        //重置实时视频窗口
        function reSetLiveVideo() {
            if (!isInitFinished) {
                return;
            } else {
                //窗口下标
                var index = $.trim($('.liveVideoIndex').val());
                if (index == '') {
                    $('.liveVideoIndex').focus();
                    return;
                }
                swfobject.getObjectById("cmsv6flash").reSetVideo(index);
            }
        }

        //开始监听
        function startMonitor() {
            if (!isInitFinished) {
                return;
            } else {
                //会话号
                var jsession = $.trim($('.monitorJsession').val());
                if (jsession == '') {
                    $('.monitorJsession').focus();
                    return;
                }
                //设备号
                var devIdno = $.trim($('.monitorDevIdno').val());
                if (devIdno == '') {
                    $('.monitorDevIdno').focus();
                    return;
                }
                //通道号
                var channel = $.trim($('.monitorChannel').val());
                if (channel == '') {
                    $('.monitorChannel').focus();
                    return;
                }
                //服务器ip
                var ip = $.trim($('.monitorServerIp').val());
                if (ip == '') {
                    $('.liveStream').focus();
                    return;
                }
                //服务器端口
                var port = $.trim($('.monitorServerPort').val());
                if (port == '') {
                    $('.monitorServerPort').focus();
                    return;
                }

                swfobject.getObjectById("cmsv6flash").setListenParam(1);
                swfobject.getObjectById("cmsv6flash").startListen(jsession, devIdno, channel, ip, port);
            }
        }

        //停止监听
        function stopMonitor() {
            if (!isInitFinished) {
                return;
            } else {
                swfobject.getObjectById("cmsv6flash").stopListen();
            }
        }

        //开始对讲
        function startTalkback() {
            if (!isInitFinished) {
                return;
            } else {
                //会话号
                var jsession = $.trim($('.talkbackJsession').val());
                if (jsession == '') {
                    $('.talkbackJsession').focus();
                    return;
                }
                //设备号
                var devIdno = $.trim($('.talkbackDevIdno').val());
                if (devIdno == '') {
                    $('.talkbackDevIdno').focus();
                    return;
                }
                //服务器ip
                var ip = $.trim($('.talkbackServerIp').val());
                if (ip == '') {
                    $('.talkbackStream').focus();
                    return;
                }
                //服务器端口
                var port = $.trim($('.talkbackServerPort').val());
                if (port == '') {
                    $('.talkbackServerPort').focus();
                    return;
                }

                swfobject.getObjectById("cmsv6flash").setTalkParam(1);
                var ret = swfobject.getObjectById("cmsv6flash").startTalkback(jsession, devIdno, 0, ip, port);
                //返回 0成功，1表示正在对讲，2表示没有mic，3表示禁用了mic
                if (ret == 0) {
                } else if (ret == 1) {
                } else if (ret == 2) {
                    alert(lang.nullMic);
                } else if (ret == 3) {
                    //alert(lang.micStop);
                    $.dialog({ id: 'talkbacktip', title: lang.talkback_openMic, content: 'url:talkbacktipSP.html', min: false, max: false, lock: true
						, autoSize: true
                    });
                } else {
                }
            }
        }

        //停止对讲
        function stopTalkback() {
            if (!isInitFinished) {
                return;
            } else {
                swfobject.getObjectById("cmsv6flash").stopTalkback();
            }
        }

        // 开始远程回放
        function startPlayback() {
            if (!isInitFinished) {
                return;
            } else {
                //窗口下标
                var index = $.trim($('.playbackVideoIndex').val());
                if (index == '') {
                    $('.playbackVideoIndex').focus();
                    return;
                }
                //回放url
                var url = $.trim($('.playbackUrl').val());
                if (url == '') {
                    $('.playbackUrl').focus();
                    return;
                }
                //回放之前先停止
                swfobject.getObjectById('cmsv6flash').stopVideo(index);
                //开始回放
                swfobject.getObjectById("cmsv6flash").startVod(index, url);
            }
        }

        //停止远程回放
        function stopPlayback() {
            if (!isInitFinished) {
                return;
            } else {
                //窗口下标
                var index = $.trim($('.playbackVideoIndex').val());
                if (index == '') {
                    $('.playbackVideoIndex').focus();
                    return;
                }
                swfobject.getObjectById("cmsv6flash").stopVideo(index);
            }
        }

        //用户登录
        function userLogin() {
            //用户名
            var account = $.trim($('.account').val());
            if (account == '') {
                $('.account').focus();
                return;
            }
            //密码
            var password = $.trim($('.password').val());
            if (password == '') {
                $('.password').focus();
                return;
            }
            var param = [];
            param.push({ name: 'account', value: account });
            param.push({ name: 'password', value: password });

            $.ajax({
                type: 'POST',
                url: 'http://' + window.location.host + '/StandardApiAction_login.action',
                data: param,
                cache: false,
                dataType: 'json',
                success: function (data) {
                    if (data.result == 0) {
                        $('.liveJsession').val(data.jsession);
                        $('.monitorJsession').val(data.jsession);
                        $('.talkbackJsession').val(data.jsession);
                    } else {
                        alert(lang.loginError);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    try {
                        if (p.onError) p.onError(XMLHttpRequest, textStatus, errorThrown);
                    } catch (e) { }
                    alert(lang.loginError);
                }
            });
        }

        //设置缓冲时长
        function setBufferInfo() {
            if (!isInitFinished) {
                return;
            } else {
                //窗口下标
                var index = $.trim($('.liveVideoIndex').val());
                if (index == '') {
                    $('.liveVideoIndex').focus();
                    return;
                }
                //最小缓冲时长
                var minBufferTime = $.trim($('.minBufferTime').val());
                //最大缓冲时长
                var maxBufferTime = $.trim($('.maxBufferTime').val());
                if (minBufferTime == '' && maxBufferTime == '') {
                    return;
                }
                if (maxBufferTime != '') {
                    swfobject.getObjectById("cmsv6flash").setBufferTimeMax(index, maxBufferTime);
                }
                if (minBufferTime != '') {
                    swfobject.getObjectById("cmsv6flash").setBufferTime(index, minBufferTime);
                }
            }
        }

        function APlistPoP2(aaaa) {
            alert("11");
            alert(aaaa);
        }



        function onTtxVideoMsg(index, type) {
            if (index != null && index != "") {
                index = parseInt(index, 10);
            }
            //窗口事件
            //window message
            if (type == "select") {
                //选中窗口     		select window
                selectIndex = index;
                $('#eventTip').text(lang.vedioEventStart + (index + 1) + lang.vedioEventEnd);
            } else if (type == "full") {
                //全屏			Full screen
            } else if (type == "norm") {
                //退出全屏			Exit full screen
            }
            //视频播放事件
            //video play messsage
            else if (type == "stop") {
                //停止播放			stop playing
                playingStatusArray[index] = false;
            } else if (type == "start") {
                //开始播放			Start play
                playingStatusArray[index] = true;
            } else if (type == "sound") {
                //开启声音			Turn on the sound
            } else if (type == "silent") {
                //静音			Mute
            } else if (type == "play") {
                //暂停或停止后重新播放			Play again after pause or stop
            } else if (type == "PicSave") {
                //截图			screenshot
            }
            //对讲事件
            //Intercom messsage
            else if (type == "startRecive" || type == "uploadRecive" || type == "loadRecive") {
                //开启对讲			Open intercom
            } else if (type == "stopTalk") {
                //关闭对讲			Turn off intercom
            } else if (type == "playRecive") {
                //对讲中			Talkback
            } else if (type == "reciveStreamStop" || type == "reciveNetError" || type == "reciveStreamNotFound") {
                //对讲异常(网络异常等)			Talkback anomalies (network exceptions, etc.)

            } else if (type == "uploadNetClosed" || type == "uploadNetError") {
                //连接异常 			Connection exception 
            } else if (type == "upload") {
                //对讲讲话			Talkback speech
            } else if (type == "uploadfull") {
                //对讲讲话结束		Talkback speech ends
            }
            //监听事件
            //Listen messsage
            else if (type == "startListen") {
                //开始监听      		Start listening	
            } else if (type == "stopListen") {
                //主动停止监听 		Active stop monitoring

            } else if (type == "listenNetError") {
                //网络异常  			Network anomaly

            } else if (type == "playListen") {
                //监听中	  		In listening
            } else if (type == "loadListen" || type == "listenStreamNotFound" || type == "listenStreamStop") {
                //等待请求监听	   	Waiting request monitoring 
            }
        }


        var selectIndex = 0;
        var playingStatusArray = [];
        //判断当前选择窗口是否播放状态
        function checkIsPlaying() {
            if (playingStatusArray[selectIndex]) {
                alert(lang.vedioPlay);
            } else {
                alert(lang.vedioNoPlay);
            }
        }
      	
    </script>
  </head>
  <body>
  	<div id="flashExample">
  		<div id="cmsv6flash"></div>
  		<div></div>
  		<div id="eventTip"></div>
  			<div class="player-params">
    			<div class="player-param">
    					<a id="isPlay" class="button button-primary button-rounded button-small" onclick="checkIsPlaying();">播放状态</a>
    			</div>
    		</div>
  	</div>
    <div id="operateExample">
    	<!--  用户登录开始 -->
    	<div class="userLogin">
    		<p id="getJsessionTitle">登录获取会话号</p>
    		<div class="player-params">
    			<div class="player-param">
    				<a class="title" id="accountTitle">用户名：</a>
    				<input style="width: 150px;" value="" class="account">
    				<a style="padding-left: 20px;" class="title" id="passwordTitle">密码：</a>
    				<input type="password" style="width: 150px;" value="" class="password">
    			</div>
    			<div class="player-param">
    				<a id="userLoginBtn" class="button button-primary button-rounded button-small" onclick="userLogin();">登录</a>
    			</div>
    		</div>
    	</div>
    	<!--  用户登录结束 -->
    	<!--  视频插件初始化开始  -->
    	<div class="videoInit">
    		<p id="videoInitTitle">初始化</p>
    		<div class="player-params">
    			<div class="player-param">
    				<a class="title" id="videoLangTitle">插件语言：</a>
    				<select style="width: 140px;" class="languagePath">
    					<option>cn.xml</option>
    					<option>en.xml</option>
    				</select>
<!--     				<input style="width: 140px;" value="cn.xml" class="languagePath"> -->
    				<a style="margin-left: 20px;" class="button button-primary button-rounded button-small settings" onclick="setVideoLanguage()">设置</a>
    			</div>
    			<div class="player-param">
    				<a class="title" id="videoWidthTitle">插件宽度：</a>
    				<input style="width: 140px;" value="400" class="playerWidth">
    				<a style="padding-left: 20px;" class="title" id="videoHeightTitle">插件高度：</a>
    				<input style="width: 140px;" value="400" class="playerHeight">
    			</div>
    			<div class="player-param">
    				<a class="title serverIp">服务器IP：</a>
    				<input style="width: 140px;" value="" id="serverIp">
    				<a style="padding-left: 20px;" class="title serverPort">服务器端口：</a>
    				<input style="width: 100px;" value="" id="serverPort">
    				<a style="margin-left: 20px;" class="button button-primary button-rounded button-small settings" onclick="setVideoServer()">设置</a>
    			</div>
    			<div class="player-param">
    				<a class="title" id="windowNumberTitle">窗口数目：</a>
    				<input style="width: 100px;" value="4" class="windowNumber">
    				<a style="margin-left: 20px;" class="button button-primary button-rounded button-small settings" onclick="setVideoWindowNumber();">设置</a>
    			</div>
    			<div class="player-param">
    				<a id="videoInitBtn" class="button button-primary button-rounded button-small" onclick="initPlayerExample();">初始化</a>
    			</div>
    		</div>
    	</div>
    	<!--  视频插件初始化结束  -->
    	<!--  实时视频开始  -->
    	<div class="videoLive">
    		<p id="videoLiveTitle">实时视频</p>
    		<div class="player-params">
    			<div class="player-param">
    				<a class="title windowIndex">窗口下标：</a>
    				<input style="width: 80px;" value="0" class="liveVideoIndex">
    				<a style="padding-left: 20px;" class="title" id="videoTitleTitle">标题：</a>
    				<input style="width: 300px;" value="vehicle123124235" class="liveWindowTitle">
    				<a style="margin-left: 20px;" class="button button-primary button-rounded button-small settings" onclick="setWindowTitle();">设置</a>
    			</div>
    			<div class="player-param">
    				<a class="title jsessionId">会话号：</a>
    				<input style="width: 300px;" value="" class="liveJsession">
    				<a style="padding-left: 20px;" class="title" id="videoStreamTitle">码流：</a>
    				<select style="width: 100px;" class="liveStream">
    					<option>0</option>
    					<option selected="selected">1</option>
    				</select>
<!--     				<input style="width: 100px;" value="1" class="liveStream"> -->
    			</div>
    			<div class="player-param">
    				<a class="title devIdnoTitle">设备号：</a>
    				<input style="width: 300px;" value="500000" class="liveDevIdno">
    				<a style="padding-left: 20px;" class="title devChannelTitle">通道：</a>
    				<input style="width: 100px;" value="0" class="liveChannel">
    			</div>
    			<div class="player-param">
    				<div>
	    				<a class="title minBufferTimeTitle">最小缓冲时长：</a>
	    				<input style="width: 80px;" value="2" class="minBufferTime">
	    				<a style="padding-left: 20px;" class="title maxBufferTimeTitle">最大缓冲时长：</a>
	    				<input style="width: 80px;" value="6" class="maxBufferTime">
	    				<a style="margin-left: 20px;" class="button button-primary button-rounded button-small settings" onclick="setBufferInfo();">设置</a>
    				</div>
					<div>
						<span id="bufferTimeDesc" style="font-size:10px;">说明：主要用于调整视频延时，当缓存的数据达到了最小缓冲时长时（默认为2秒），则会进行播放，当到了最大缓冲时长（默认为6秒），则进行快放。</span>
					</div>
    			</div>
    			<div class="player-param">
    				<a id="videoPlayBtn" class="button button-primary button-rounded button-small" onclick="playLiveVideo();">播放</a>
    				<a style="margin-left: 20px;" class="button button-primary button-rounded button-small stop" onclick="stopLiveVideo()">停止</a>
    				<a id="videoResetBtn" style="margin-left: 20px;" class="button button-primary button-rounded button-small" onclick="reSetLiveVideo()">重置</a>
    			</div>
    		</div>
    	</div>
    	<!--  实时视频结束  -->
    	<!--  监听开始  -->
    	<div class="monitor">
    		<p id="monitorTitle">监听</p>
    		<div class="player-params">
    			<div class="player-param">
    				<a class="title jsessionId">会话号：</a>
    				<input style="width: 400px;" value="" class="monitorJsession">
    			</div>
    			<div class="player-param">
    				<a class="title devIdnoTitle">设备号：</a>
    				<input style="width: 200px;" value="500000" class="monitorDevIdno">
    				<a style="padding-left: 20px;" class="title devChannelTitle">通道：</a>
    				<input style="width: 120px;" value="0" class="monitorChannel">
    			</div>
    			<div class="player-param">
    				<a class="title serverIp">服务器IP：</a>
    				<input style="width: 200px;" value="" class="monitorServerIp">
    				<a style="padding-left: 20px;" class="title serverPort">端口：</a>
    				<input style="width: 100px;" value="" class="monitorServerPort">
    			</div>
    			<div class="player-param">
    				<a id="monitorBtn" class="button button-primary button-rounded button-small" onclick="startMonitor();">监听</a>
    				<a style="margin-left: 20px;" class="button button-primary button-rounded button-small stop" onclick="stopMonitor()">停止</a>
    			</div>
    		</div>
    	</div>
    	<!--  监听结束  -->
    	<!--  对讲开始  -->
    	<div class="talkback">
    		<p id="talkbackTitle">对讲</p>
    		<div class="player-params">
    			<div class="player-param">
    				<a class="title jsessionId">会话号：</a>
    				<input style="width: 400px;" value="" class="talkbackJsession">
    			</div>
    			<div class="player-param">
    				<a class="title devIdnoTitle">设备号：</a>
    				<input style="width: 400px;" value="500000" class="talkbackDevIdno">
    			</div>
    			<div class="player-param">
    				<a class="title serverIp">服务器IP：</a>
    				<input style="width: 200px;" value="" class="talkbackServerIp">
    				<a style="padding-left: 20px;" class="title serverPort">端口：</a>
    				<input style="width: 100px;" value="" class="talkbackServerPort">
    			</div>
    			<div class="player-param">
    				<a id="talkbackBtn" class="button button-primary button-rounded button-small" onclick="startTalkback();">对讲</a>
    				<a style="margin-left: 20px;" class="button button-primary button-rounded button-small stop" onclick="stopTalkback()">停止</a>
    			</div>
    		</div>
    	</div>
    	<!--  对讲结束  -->
    	<!--  远程回放开始  -->
    	<div class="playback">
    		<p id="playbackTitle">远程回放</p>
    		<div class="player-params">
    			<div class="player-param">
    				<a class="title windowIndex">窗口下标：</a>
    				<input style="width: 80px;" value="0" class="playbackVideoIndex">
    			</div>
    			<div class="player-param">
    				<a id="urlTitle" class="title">url链接：</a>
    				<textarea style="width: 400px;height:100px;" class="playbackUrl">http://127.0.0.1:6604/3/5?DownType=5&DevIDNO=10009&FILELOC=1&FILESVR=0&FILECHN=0&FILEBEG=1&FILEEND=100&PLAYIFRM=0&PLAYFILE=/mnt/hgfs/linux/libdvrnet/jni/demo/bin/record/H20121123-112931P3A1P0.avi&PLAYBEG=0&PLAYEND=0&PLAYCHN=0</textarea>
    			</div>
    			<div class="player-param">
    				<a id="playbackBtn" class="button button-primary button-rounded button-small" onclick="startPlayback();">开始回放</a>
    				<a style="margin-left: 20px;" class="button button-primary button-rounded button-small stop" onclick="stopPlayback()">停止回放</a>
    			</div>
    		</div>
    	</div>
    	<!--  远程回放开始  -->

        <asp:GridView ID="GridView1" runat="server" Font-Size="12px" AutoGenerateColumns="False"
                            BorderWidth="0px" CssClass="table table-bordered table-hover table-condensed"
                            AllowSorting="True" ShowHeader="true">
                            <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" />
                            <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" />
                            <Columns>
                               
                                <asp:TemplateField HeaderText="发票资料管理" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        
                                        <button type="button" style="background-color: transparent; border: 0"
                                            onclick="APlistPoP2('<%# Container.DataItemIndex + 1 %>');">
                                            <span class="glyphicon glyphicon-list-alt">操2作</span>
                                        </button>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
    </div>
  </body>
</html>
