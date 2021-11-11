/*
 *  Scroller object to handle scrolling.
 */
const scrollerProto = ((plugin) => {
  const initHandlers = (el) => {
    const self = this;
    // The scroll event. We want to keep track of when the user is scrolling the transcript.
    el.addEventListener('scroll', () => {
      if (self.isAutoScrolling) {
        // If isAutoScrolling was set to true, we can set it to false and then ignore this event.
        // It wasn't the user.
        self.isAutoScrolling = false; // event handled
      } else {
        // We only care about when the user scrolls. Set userIsScrolling to true and add a nice class.
        self.userIsScrolling = true;
        el.classList.add('is-inuse');
      }
    });

    // The mouseover event.
    el.addEventListener('mouseenter', () => {
      self.mouseIsOverTranscript = true;
    });
    el.addEventListener('mouseleave', () => {
      self.mouseIsOverTranscript = false;

      // Have a small delay before deciding user as done interacting.
      setTimeout(() => {
        // Make sure the user didn't move the pointer back in.
        if (!self.mouseIsOverTranscript) {
          self.userIsScrolling = false;
          el.classList.remove('is-inuse');
        }
      }, 1000);
    });
  };

  // Init instance constiables
  const init = (element, plugin) => {
    this.element = element;
    this.userIsScrolling = false;

    // default to true in case user isn't using a mouse;
    this.mouseIsOverTranscript = true;
    this.isAutoScrolling = true;
    initHandlers.call(this, this.element);
    return this;
  };

  // Easing function for smoothness.
  const easeOut = (time, start, change, duration) => {
    return start + change * Math.sin(Math.min(1, time / duration) * (Math.PI / 2));
  };

  // Animate the scrolling.
  const scrollTo = (element, newPos, duration) => {
    const startTime = Date.now();
    const startPos = element.scrollTop;
    const self = this;

    // Don't try to scroll beyond the limits. You won't get there and this will loop forever.
    newPos = Math.max(0, newPos);
    newPos = Math.min(element.scrollHeight - element.clientHeight, newPos);
    const change = newPos - startPos;

    // This inner function is called until the elements scrollTop reaches newPos.
    const updateScroll = () => {
      const now = Date.now();
      const time = now - startTime;
      self.isAutoScrolling = true;
      element.scrollTop = easeOut(time, startPos, change, duration);
      if (element.scrollTop !== newPos) {
        requestAnimationFrame(updateScroll, element);
      }
    };
    requestAnimationFrame(updateScroll, element);
  };

  // Scroll an element's parent so the element is brought into view.
  const scrollToElement = function (element) {
    if (this.canScroll()) {
      const parent = element.parentElement;
      const parentOffsetBottom = parent.offsetTop + parent.clientHeight;
      const elementOffsetBottom = element.offsetTop + element.clientHeight;
      const relTop = element.offsetTop - parent.offsetTop;
      const relBottom = element.offsetTop + element.clientHeight - parent.offsetTop;
      let newPos;

      // If the top of the line is above the top of the parent view, were scrolling up,
      // so we want to move the top of the element downwards to match the top of the parent.
      if (relTop < parent.scrollTop) {
        newPos = element.offsetTop - parent.offsetTop;

        // If the bottom of the line is below the parent view, we're scrolling down, so we want the
        // bottom edge of the line to move up to meet the bottom edge of the parent.
      } else if (relBottom > parent.scrollTop + parent.clientHeight) {
        newPos = elementOffsetBottom - parentOffsetBottom;
      }

      // Don't try to scroll if we haven't set a new position.  If we didn't
      // set a new position the line is already in view (i.e. It's not above
      // or below the view)
      // And don't try to scroll when the element is already in position.
      if (newPos !== undefined && parent.scrollTop !== newPos) {
        scrollTo.call(this, parent, newPos, 400);
      }
    }
  };

  // Return whether the element is scrollable.
  const canScroll = function () {
    const el = this.element;
    return el.scrollHeight > el.offsetHeight;
  };

  // Return whether the user is interacting with the transcript.
  const inUse = () => {
    return this.userIsScrolling;
  };

  return {
    init,
    to: scrollToElement,
    canScroll,
    inUse,
  };
})(my);

const scroller = (element) => {
  return Object.create(scrollerProto).init(element);
};
