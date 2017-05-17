export class PrincipalService {
    constructor(TokenService, UserInfoService, $q) {
        this.TokenService = TokenService;
        this.UserInfoService = UserInfoService;
        this.user = {};
        this.isLoggedIn = false;
        this.q = $q;
        this.tryGetUserInfo().catch(() => {
            this.isLoggedIn = false;
        });
    }

    authenticate(token) {
        this.TokenService.addToken(token);
        return this.tryGetUserInfo();
    }

    logout() {
        if (this.isLoggedIn) {
            this.user = {};
            this.isLoggedIn = false;
            this.TokenService.removeToken();
        }
    }

    tryGetUserInfo() {
        let deffered = this.q.defer();
        this.UserInfoService.getUserInfo().then(
            (response) => {
                this.user =  response.data || response;
                this.isLoggedIn = true;
                console.log('user');
            console.log(this.user);
                deffered.resolve(true);
            },
            (errorResponse) => {
                this.isLoggedIn = false;
                this.user = {};
                deffered.reject(false);
            });
            
            return deffered.promise;
    }
}