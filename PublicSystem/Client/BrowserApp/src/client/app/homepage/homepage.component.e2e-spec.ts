describe('homepage', () => {

  beforeEach( () => {
    browser.get('/');
  });

  it('should have correct feature heading', () => {
    expect(element(by.css('sd-homepage h2')).getText()).toEqual('Features');
  });

});
