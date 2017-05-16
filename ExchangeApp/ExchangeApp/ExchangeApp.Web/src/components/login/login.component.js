class LoginController {

    constructor(AuthService, $state) {
        this.authService = AuthService;
        this.user = {};
        this.errorMessage = "";
        this.state = $state;
    }

    login(event) {
        this.authService.login(this.user.username, this.user.password).then(
            (response) => {
                this.state.go('restricted.home', {}, { reload: true });
            },
            (error) => {
                error = error.data || error;
                this.errorMessage = error.error_description;
            });
    }

    update(userData) {
        this.user = userData;
    }
}

export let LoginComponent = {
    controller: LoginController,
    template: require('./login.component.html')
}