/* I copied this code from the video:
 *    HTML Video Programming #5 Make your own videojs plugin
 *    https://www.youtube.com/watch?v=ITPdp6kw-B0
 * It is not directly called anywhere, but I used most of the code in:
 *    src\WebUI\WebApp\clientapp\src\app\common\videojs\vjsutils\AddButtons.ts
 * "rotate" plugin for videojs
 * We need to first install the plugin "zoomrotate".
 *   CMD: npm i videojs-rotatezoom
 *   HTML: <script src='videojs.zoomrotate.js'></script>
 *   JS: video.zoomrotate({
          rotate: 90,
          zoom: 1.5
          }
        });
      OR
        data-setup='{ "plugins": { "zoomrotate": {
          "rotate": "90", "zoom": "1.5" } } }'
 * We would call this plugin from our video initialize code using:
 *    player.rotate(player);
 */

function rotate(player) {
  var dimension = 0;
  var rotateLeftIcon = '&#8635;';
  var rotateRightIcon = '&#8634;';

  // Create 2 buttons after the playbackRate button
  var rotateLeftButton = createButton(rotateLeftIcon);
  var rotateRightButton = createButton(rotateRightIcon);

  rotateLeftButton.onclick = function () {
    dimension += 90;
    dimension %= 360;
    player.zoomrotate({ rotate: dimension });
  };

  rotateRightButton.onclick = function () {
    dimension -= 90;
    if (Math.abs(dimension) == 360) {
      dimension = 0;
    }
    player.zoomrotate({ rotate: dimension });
  };

  var playbackRate = document.querySelector('vjs-playback-rate');
  insertAfter(rotateLeftButton, playbackRate);
  insertAfter(rotateRightButton, rotateLeftButton);

  function createButton(icon) {
    var button = document.createElement('button');
    button.classList.add('vjs-menu-button');
    // create "rotate" icon. [ When I pasted the code sequence below into
    // a Google search, it displayed a roatate icon. ]
    button.innerHTML = icon;
    button.style.fontSize = '1.8em';
    return button;
  }

  function insertAfter(newEl, element) {
    element.parentNode.insertBefore(newEl, element.nextSibling);
  }
}

videojs.registerPlugin('rotate', rotate);
