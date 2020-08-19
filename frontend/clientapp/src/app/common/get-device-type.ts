// Methods for determining device type

export enum DeviceType {
  desktop,
  tablet,
  mobile,
}

export function checkDeviceType() {
  const width = window.innerWidth;
  let deviceType: DeviceType;
  if (width <= 768) {
    deviceType = DeviceType.mobile;
    this.deviceType = 'Mobile';
  } else if (width > 768 && width <= 992) {
    deviceType = DeviceType.tablet;
    this.deviceType = 'Tablet';
  } else {
    deviceType = DeviceType.desktop;
    this.deviceType = 'Desktop';
  }
  return deviceType;
}

export function isMobile() {
  return this.checkDeviceType() === DeviceType.mobile;
}
