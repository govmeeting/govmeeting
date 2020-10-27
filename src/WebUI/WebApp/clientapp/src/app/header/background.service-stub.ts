// The background image will normally be stored in the database and be
// retrieved from the backend. This is a stub till that code is completed.

export function getBackgroundUrl(location: string) {
  let background;

  switch (location) {
    case 'Boothbay Harbor': {
      background = "url('/assets/images/Boothbay_Harbor_inner_harbor.png')";
      break;
    }
    case 'Lincoln County': {
      background = "url('/assets/images/Lincoln_County_Pemaquid_Lighthouse.png')";
      break;
    }
    case 'State of Maine': {
      background = "url('/assets/images/Maine_Acadia_National_Park.png')";
      break;
    }
    case 'United States': {
      background = "url('/assets/images/United_States_Capitol.png')";
      break;
    }
    case 'Glendale HOA': {
      background = "url('/assets/images/condominiums.png')";
      break;
    }
    case 'generic': {
      background = "url('/assets/images/Budget_Town_Hall.png')";
      break;
    }

    // These may be needed when we add a second sample GovEntity.
    //   case 'Austin': { background = "url('/assets/images/Austin.png')"; break; }
    //   case 'Travis County': { background = "url('/assets/images/Travis_County.png')"; break; }
    //   case 'State of Texas': { background = "url('/assets/images/Texas_State_Capitol.png')"; break; }
  }
  return background;
}
