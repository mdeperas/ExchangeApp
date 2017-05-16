export function interceptors($httpProvider) {
    $httpProvider.interceptors.push('authInterceptor');
}

export function authInterceptor(TokenService) {
    return {
        request: (config) => {
            config.headers = config.headers || {};
            
            let token = TokenService.getToken();
            if(token && token.expires_in && token.expires_in > new Date().getTime())
            {
                config.headers.Authorization = 'Bearer ' + token.access_token; 
            }

            return config;
        }
    }
}