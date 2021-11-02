import { ElementRef } from '@angular/core';

const NoLog = true; // set to false for console logging
const ClassName = 'Videojs-util: ';

// Create buttons, attach click handlers and add them to the video player control bar.
export function AddRotateButtons(vjscontainer: ElementRef) {
  var dimension = 0;
  // I you paste either of these code sequences into a Google search box and hit
  //   search, you will see the symbol it represents.
  var rotateLeftIcon = '&#8635;';
  var rotateRightIcon = '&#8634;';

  NoLog || console.log(ClassName + 'about to create button');
  var rotateLeftButton = createButton(rotateLeftIcon);
  var rotateRightButton = createButton(rotateRightIcon);

  rotateLeftButton.onclick = function () {
    dimension += 90;
    dimension %= 360;
    // player.zoomrotate({ rotate: dimension });
  };

  rotateRightButton.onclick = function () {
    dimension -= 90;
    if (Math.abs(dimension) == 360) {
      dimension = 0;
    }
    // player.zoomrotate({ rotate: dimension });
  };

  // Add the buttons after the playbackRate button
  var playbackRate = vjscontainer.nativeElement.querySelector('.vjs-playback-rate');
  insertAfter(rotateLeftButton, playbackRate);
  insertAfter(rotateRightButton, rotateLeftButton);
}

function createButton(icon: string) {
  NoLog || console.log(ClassName + 'inside createButton');
  var button = document.createElement('button');
  button.classList.add('vjs-menu-button');
  // create "rotate" icon. [ When I pasted the code sequence below into
  // a Google search, it displayed a roatate icon. ]
  button.innerHTML = icon;
  button.style.fontSize = '1.8em';
  NoLog || console.log(ClassName + 'about to return button');
  return button;
}

function insertAfter(newEl, element) {
  element.parentNode.insertBefore(newEl, element.nextSibling);
}
