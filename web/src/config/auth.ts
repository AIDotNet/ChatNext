
declare global {
    interface ProcessEnv {
        enableAuth?: boolean;
    }
}

declare var window: Window & typeof globalThis & { process: { env: ProcessEnv } };

export const getAuthConfig = (): ProcessEnv => {

    const enableAuth = window?.process?.env?.enableAuth ?? false;

    return {
        enableAuth
    };
};

export const authEnv = getAuthConfig();
