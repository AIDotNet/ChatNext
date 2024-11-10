import { ActionIcon } from '@lobehub/ui';
import { createStyles } from 'antd-style';
import { MessageSquarePlus } from 'lucide-react';
import { memo } from 'react';
import { Flexbox } from 'react-layout-kit';

import { ProductLogo } from '@/components/Branding';
import { DESKTOP_HEADER_ICON_SIZE } from '@/const/layoutTokens';
import { useActionSWR } from '@/libs/swr';
import { useSessionStore } from '@/store/session';

import SessionSearchBar from '../../features/SessionSearchBar';

export const useStyles = createStyles(({ css, token }) => ({
    logo: css`
    color: ${token.colorText};
    fill: ${token.colorText};
  `,
    top: css`
    position: sticky;
    inset-block-start: 0;
  `,
}));

const Header = memo(() => {
    const { styles } = useStyles();
    const [createSession] = useSessionStore((s) => [s.createSession]);

    const { mutate, isValidating } = useActionSWR('session.createSession', () => createSession());

    return (
        <Flexbox className={styles.top} gap={16} padding={16}>
            <Flexbox distribution={'space-between'} horizontal>
                <Flexbox align={'center'} gap={4} horizontal>
                    <ProductLogo className={styles.logo} size={36} type={'text'} />
                </Flexbox>
                <ActionIcon
                    icon={MessageSquarePlus}
                    loading={isValidating}
                    onClick={() => mutate()}
                    size={DESKTOP_HEADER_ICON_SIZE}
                    style={{ flex: 'none' }}
                    title={'创建会话'}
                />
            </Flexbox>
            <SessionSearchBar />
        </Flexbox>
    );
});

export default Header;
