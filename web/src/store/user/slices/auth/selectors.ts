import { BRANDING_NAME } from '@/const/branding';
import { UserStore } from '@/store/user';
import { LobeUser } from '@/types/user';

const DEFAULT_USERNAME = BRANDING_NAME;

const nickName = (s: UserStore) => {
    if (!s.enableAuth()) return '社区版用户';

    if (s.isSignedIn) return s.user?.fullName || s.user?.username;

    return '匿名用户';
};

const username = (s: UserStore) => {
    if (!s.enableAuth()) return DEFAULT_USERNAME;

    if (s.isSignedIn) return s.user?.username;

    return 'anonymous';
};

export const userProfileSelectors = {
    nickName,
    userAvatar: (s: UserStore): string => s.user?.avatar || '',
    userId: (s: UserStore) => s.user?.id,
    userProfile: (s: UserStore): LobeUser | null | undefined => s.user,
    username,
};

/**
 * 使用此方法可以兼容不需要登录鉴权的情况
 */
const isLogin = (s: UserStore) => {
    // 如果没有开启鉴权，说明不需要登录，默认是登录态
    if (!s.enableAuth()) return true;

    return s.isSignedIn;
};

export const authSelectors = {
    enabledAuth: (s: UserStore): boolean => s.enableAuth(),
    enabledNextAuth: (s: UserStore): boolean => !!s.enabledNextAuth,
    isLoaded: (s: UserStore) => s.isLoaded,
    isLogin,
    isLoginWithAuth: (s: UserStore) => s.isSignedIn,
};
