export default function transition($transitions) {
    $transitions.onBefore({ to: 'restricted.*' }, (transition) => {
        let principalService = transition.injector().get('PrincipalService');

        if (!principalService.isLoggedIn) {
            return principalService.tryGetUserInfo().catch(() => {
                return transition.router.stateService.target('free.login');
            });
        }
    })
};