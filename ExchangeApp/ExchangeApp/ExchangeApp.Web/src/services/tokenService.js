let accessTokenKey = "accessToken";
export class TokenService {
    constructor() {
    }

    addToken(token) {
        let expiresAt = new Date();
        let expires_in = expiresAt.setSeconds(expiresAt.getSeconds() + token.expires_in);        

        let accessToken = {
            expires_in: expires_in,
            access_token: token.access_token
        };

        sessionStorage.setItem(accessTokenKey, JSON.stringify(accessToken));
    }

    removeToken() {
        sessionStorage.removeItem(accessTokenKey);
    }

    getToken() {
        return JSON.parse(sessionStorage.getItem(accessTokenKey));
    }
}