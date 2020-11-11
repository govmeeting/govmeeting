// Methods for determining device type

export enum DeviceType {
  desktop,
  tablet,
  mobile,
}

export class GetDeviceType {
  deviceType: DeviceType;

  static checkDeviceType() {
    const width = window.innerWidth;
    let deviceType: DeviceType;
    if (width <= 768) {
      deviceType = DeviceType.mobile;
    } else if (width > 768 && width <= 992) {
      deviceType = DeviceType.tablet;
    } else {
      deviceType = DeviceType.desktop;
    }
    return deviceType;
  }

  static isMobile() {
    return this.checkDeviceType() === DeviceType.mobile;
  }
}
