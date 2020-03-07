## Modifying the Dashboard

### Add a new new card for new feature </h4>

*  At a terminal prompt, move to the folder: FrontEnd/ClientApp
*  Enter: ng generate component your-feature
*  Add your functionality to the files in : FrontEnd/ClientApp/src/app/your-feature
*  Insert a new gm-small-card or gm-large-card element in app/dash-main/dash-main.html.
*  Modify the icon, iconcolor, title, etc of the card element.
* If you need access to the name of the currently selected location and agency in your controller:
  * Add the location and agency input attributes to your feature element
  * Add location and agency @Input properties in your controller.

(See the other samples in dash-main.html)

### Re-arrange cards

1. Open the file: FrontEnd/ClientApp/src/app/dash-main/dash-main.html.
1. Change the card positions by
  changing the position of the gm-small-card or gm-large-card elements in this file.
