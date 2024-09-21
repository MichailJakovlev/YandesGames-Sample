mergeInto(LibraryManager.library, {
  
    SendGameReady: function() {
      YaGames.init()
      .then((ysdk) => {
        ysdk.features.LoadingAPI.ready()
    })
    .catch(console.error);
    },
  
    SendGameStart: function() {
      try {
        ysdk.features.GameplayAPI.start()
      } catch(err) {
        console.error;
      }
    },
  
    SendGameStop: function() {
      try {
        ysdk.features.GameplayAPI.stop()
      } catch(err) {
        console.error;
      }
    },
  
    GetLang: function () {
      try {
        var lang = ysdk.environment.i18n.lang;
        var bufferSize = lengthBytesUTF8(lang) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(lang, buffer, bufferSize);
        console.log('YSDK LANG', buffer);
        return buffer;
      } catch(err) {
        // взять язык с браузера
        var lang = navigator.language;
        var bufferSize = lengthBytesUTF8(lang) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(lang, buffer, bufferSize);
        console.log('NAVIGATOR', buffer);
        return buffer;
      }
      },
  
    ShowAd : function(){
      ysdk.adv.showFullscreenAdv({
      callbacks: {
          onClose: function(wasShown) {
            gameInstance.SendMessage('GameState', 'StartGame');
          },
          onError: function(error) {
          }
      }
  })
  },
    ShowReward : function(){
      ysdk.adv.showRewardedVideo({
      callbacks: {
          onOpen: () => {
            console.log('Reward Video Opened');
          },
          onRewarded: () => {
            gameInstance.SendMessage('YandexManager', 'Rewarded');
            console.log('Reward Video Watched');
          },
          onClose: () => {
            gameInstance.SendMessage('GameState', 'StartGame');
            console.log('Reward Video Closed');
          },
          onError: (e) => {
            console.log('Error while open video ad:', e);
          }
      }
  })
  },
  });