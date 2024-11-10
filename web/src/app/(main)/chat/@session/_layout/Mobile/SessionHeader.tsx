'use client';

import { ActionIcon, MobileNavBar } from '@lobehub/ui';
import { MessageSquarePlus } from 'lucide-react';
import { useNavigate } from 'react-router-dom';
import { memo } from 'react';
import { Flexbox } from 'react-layout-kit';

import { ProductLogo } from '@/components/Branding';
import { MOBILE_HEADER_ICON_SIZE } from '@/const/layoutTokens';
import UserAvatar from '@/features/User/UserAvatar';
import { useSessionStore } from '@/store/session';
import { mobileHeaderSticky } from '@/styles/mobileHeader';

const Header = memo(() => {
    const [createSession] = useSessionStore((s) => [s.createSession]);
    const router = useNavigate();

    return (
        <MobileNavBar
            left={
                <Flexbox align={'center'} gap={8} horizontal style={{ marginLeft: 8 }}>
                    <UserAvatar onClick={() => router('/me')} size={32} />
                    <ProductLogo type={'text'} />
                </Flexbox>
            }
            right={
                <ActionIcon
                    icon={MessageSquarePlus}
                    onClick={() => createSession()}
                    size={MOBILE_HEADER_ICON_SIZE}
                />
            }
            style={mobileHeaderSticky}
        />
    );
});

export default Header;
