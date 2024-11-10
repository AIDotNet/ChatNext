import { LobeUser } from '@/types/user';

export interface UserAuthState {
    enabledNextAuth?: boolean;
    isLoaded?: boolean;
    isSignedIn?: boolean;
    oAuthSSOProviders?: string[];
    user?: LobeUser;
}

export const initialAuthState: UserAuthState = {};
