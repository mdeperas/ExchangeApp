class AppController {
  constructor(PrincipalService, $state) {
    this.principalService = PrincipalService;
    this.state = $state;
  }

  logout() {
    this.principalService.logout();
    this.state.go('home', {}, { reload: true });
  }
}

export let AppComponent = {
    controller: AppController,
    template: require('./app.component.html')
}