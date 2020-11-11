describe("Home test", () => {
  it("Can visit home and get language combo", () => {
    cy.visit("/");
    cy.get('#language');
  });});
