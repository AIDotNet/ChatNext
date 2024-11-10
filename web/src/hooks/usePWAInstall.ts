import { pwaInstallHandler } from 'pwa-install-handler';
import { useEffect, useState } from 'react';
import { PWA_INSTALL_ID } from '@/const/layoutTokens';

import { usePlatform } from './usePlatform';

export const usePWAInstall = () => {
    const [canInstall, setCanInstall] = useState(false);
    const { isSupportInstallPWA, isPWA } = usePlatform();

    useEffect(() => {
        pwaInstallHandler.addListener(setCanInstall);
        return () => {
            pwaInstallHandler.removeListener(setCanInstall);
        };
    }, []);

    const installCheck = () => {
        // 当在 PWA 或不支持 PWA 的环境中时，不显示安装按钮
        if (isPWA || !isSupportInstallPWA) return false;
        const pwa: any = document.querySelector(`#${PWA_INSTALL_ID}`);
        if (!pwa) return false;
        return canInstall;
    };

    return {
        canInstall: installCheck(),
        install: () => {
            const pwa: any = document.querySelector(`#${PWA_INSTALL_ID}`);
            if (!pwa) return;
            pwa.externalPromptEvent = pwaInstallHandler.getEvent();
            pwa?.showDialog(true);
        },
    };
};
