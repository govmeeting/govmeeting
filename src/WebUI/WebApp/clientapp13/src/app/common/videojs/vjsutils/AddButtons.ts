import { ElementRef } from '@angular/core';

const NoLog = true; // set to false for console logging
const ClassName = 'Videojs-util: ';

let angle = 0;
export function RotateVideo(vjscontainer: ElementRef) {
  angle += 90;
  angle = angle % 360;
  const transform = 'rotate(' + angle.toString() + 'deg)';
  vjscontainer.nativeElement.style.transform = transform;
}

// Create buttons, attach click handlers and add them to the video player control bar.
export function AddRotateButtons(vjscontainer: ElementRef) {
  let dimension = 0;
  // I you paste either of these code sequences into a Google search box and hit
  //   search, you will see the symbol it represents.
  const rotateLeftIcon = '&#8635;';
  const rotateRightIcon = '&#8634;';

  NoLog || console.log(ClassName + 'about to create button');
  const rotateLeftButton = createButton(rotateLeftIcon);
  const rotateRightButton = createButton(rotateRightIcon);

  rotateLeftButton.onclick = () => {
    dimension += 180;
    dimension %= 360;
    const transform = 'rotate(' + dimension.toString() + 'deg)';
    vjscontainer.nativeElement.style.transform = transform;

    // player.zoomrotate({ rotate: dimension });
  };

  rotateRightButton.onclick = () => {
    dimension -= 180;
    if (Math.abs(dimension) === 360) {
      dimension = 0;
    }
    const transform = 'rotate(' + dimension.toString() + 'deg)';
    vjscontainer.nativeElement.style.transform = transform;

    // player.zoomrotate({ rotate: dimension });
  };

  // Add the buttons after the playbackRate button
  const playbackRate = vjscontainer.nativeElement.querySelector('.vjs-playback-rate');
  insertAfter(rotateLeftButton, playbackRate);
  insertAfter(rotateRightButton, rotateLeftButton);
}

function createButton(icon: string) {
  NoLog || console.log(ClassName + 'inside createButton');
  const button = document.createElement('button');
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
