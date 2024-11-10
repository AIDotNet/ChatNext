import { authEnv } from '@/config/auth';

export const enableAuth = authEnv.enableAuth;

export const LOBE_CHAT_AUTH_HEADER = 'X-chat-next-auth';

export const OAUTH_AUTHORIZED = 'X-oauth-authorized';

export const JWT_SECRET_KEY = 'Chat Next';
export const NON_HTTP_PREFIX = 'http_nosafe';

/* eslint-disable typescript-sort-keys/interface */
export interface JWTPayload {
    /**
     * password
     */
    accessCode?: string;
    /**
     * Represents the user's API key
     *
     * If provider need multi keys like bedrock,
     * this will be used as the checker whether to use frontend key
     */
    apiKey?: string;
    /**
     * Represents the endpoint of provider
     */
    endpoint?: string;

    /**
     * user id
     * in client db mode it's a uuid
     * in server db mode it's a user id
     */
    userId?: string;
}
/* eslint-enable */
