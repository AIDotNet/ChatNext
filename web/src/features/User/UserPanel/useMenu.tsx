import { ActionIcon, DiscordIcon, Icon } from '@lobehub/ui';
import { Badge } from 'antd';
import { ItemType } from 'antd/es/menu/interface';
import {
    Book,
    CircleUserRound,
    Download,
    Feather,
    LifeBuoy,
    LogOut,
    Mail,
    Maximize,
    Settings2,
} from 'lucide-react';
import { PropsWithChildren, memo } from 'react';
import { Flexbox } from 'react-layout-kit';
import urlJoin from 'url-join';

import type { MenuProps } from '@/components/Menu';
import {
    DISCORD,
    DOCUMENTS_REFER_URL,
    EMAIL_SUPPORT,
    GITHUB_ISSUES,
    mailTo,
} from '@/const/url';
import { useUserStore } from '@/store/user';
import { authSelectors } from '@/store/user/selectors';

import { useNewVersion } from './useNewVersion';
import { Link } from 'react-router-dom';
import { enableAuth } from '@/const/auth';
import { useQueryRoute } from '@/hooks/useQueryRoute';
import { usePWAInstall } from '@/hooks/usePWAInstall';
import { useOpenSettings } from '@/hooks/useInterceptingRoutes';

const NewVersionBadge = memo(
    ({
        children,
        showBadge,
        onClick,
    }: PropsWithChildren & { onClick: () => void; showBadge?: boolean }) => {
        if (!showBadge)
            return (
                <Flexbox flex={1} onClick={onClick}>
                    {children}
                </Flexbox>
            );
        return (
            <Flexbox align={'center'} flex={1} gap={8} horizontal onClick={onClick} width={'100%'}>
                <span>{children}</span>
                <Badge count={'有新版本'} />
            </Flexbox>
        );
    },
);

export const useMenu = () => {
    const router = useQueryRoute();
    const { canInstall, install } = usePWAInstall();
    const hasNewVersion = useNewVersion();
    const openSettings = useOpenSettings();
    const [isLogin, isLoginWithAuth, openUserProfile] = useUserStore((s) => [
        authSelectors.isLogin(s),
        authSelectors.isLoginWithAuth(s),
        s.openUserProfile,
    ]);

    const profile: MenuProps['items'] = [
        {
            icon: <Icon icon={CircleUserRound} />,
            key: 'profile',
            label: '个人资料',
            onClick: () => openUserProfile(),
        },
    ];

    const settings: MenuProps['items'] = [
        {
            extra: (
                <ActionIcon
                    icon={Maximize}
                    onClick={() => router.push(urlJoin('/settings'))}
                    size={'small'}
                    title={'全屏模型'}
                />
            ),
            icon: <Icon icon={Settings2} />,
            key: 'setting',
            label: (
                <NewVersionBadge onClick={openSettings} showBadge={hasNewVersion}>
                    {'设置'}
                </NewVersionBadge>
            ),
        },
        {
            type: 'divider',
        },
    ];

    /* ↓ cloud slot ↓ */

    /* ↑ cloud slot ↑ */

    const pwa: MenuProps['items'] = [
        {
            icon: <Icon icon={Download} />,
            key: 'pwa',
            label: '安装PWA',
            onClick: () => install(),
        },
        {
            type: 'divider',
        },
    ];

    const helps: MenuProps['items'] = [
        {
            icon: <Icon icon={DiscordIcon} />,
            key: 'discord',
            label: (
                <Link to={DISCORD} target={'_blank'}>
                    Discord
                </Link>
            ),
        },
        {
            children: [
                {
                    icon: <Icon icon={Book} />,
                    key: 'docs',
                    label: (
                        <Link to={DOCUMENTS_REFER_URL} target={'_blank'}>
                            文档
                        </Link>
                    ),
                },
                {
                    icon: <Icon icon={Feather} />,
                    key: 'feedback',
                    label: (
                        <Link to={GITHUB_ISSUES} target={'_blank'}>
                            反馈
                        </Link>
                    ),
                },
                {
                    icon: <Icon icon={Mail} />,
                    key: 'email',
                    label: (
                        <Link to={mailTo(EMAIL_SUPPORT)} target={'_blank'}>
                            邮箱
                        </Link>
                    ),
                },
            ],
            icon: <Icon icon={LifeBuoy} />,
            key: 'help',
            label: '帮助',
        },
        {
            type: 'divider',
        },
    ].filter(Boolean) as ItemType[];

    const mainItems = [
        {
            type: 'divider',
        },
        ...(isLogin ? settings : []),
        ...(enableAuth ? profile : []),
        /* ↓ cloud slot ↓ */

        /* ↑ cloud slot ↑ */
        ...(canInstall ? pwa : []),
        ...helps,
    ].filter(Boolean) as MenuProps['items'];

    const logoutItems: MenuProps['items'] = isLoginWithAuth
        ? [
            {
                icon: <Icon icon={LogOut} />,
                key: 'logout',
                label: <span>
                    退出登录
                </span>,
            },
        ]
        : [];

    return { logoutItems, mainItems };
};
