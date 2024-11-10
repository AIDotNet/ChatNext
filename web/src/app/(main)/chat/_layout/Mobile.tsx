import { createStyles } from 'antd-style';
import { memo, useEffect } from 'react';
import { Flexbox } from 'react-layout-kit';

import { useQuery } from '@/hooks/useQuery';
import { useNavigate } from 'react-router-dom';

const useStyles = createStyles(({ css, token }) => ({
    main: css`
    position: relative;
    overflow: hidden;
    background: ${token.colorBgLayout};
  `,
}));

const Layout = memo(({ }) => {
    const { showMobileWorkspace } = useQuery();
    const { styles } = useStyles();

    const navigate = useNavigate();
    useEffect(() => {
        document.title = 'Chat';
        const token = localStorage.getItem('token');
        if (!token) {
            navigate('/login');
        }
    }, []);

    return (
        <>
            <Flexbox
                className={styles.main}
                height="100%"
                style={showMobileWorkspace ? { display: 'none' } : undefined}
                width="100%"
            >
                Sidebar
            </Flexbox>
            <Flexbox
                className={styles.main}
                height="100%"
                style={showMobileWorkspace ? undefined : { display: 'none' }}
                width="100%"
            >
                Workspace
            </Flexbox>
        </>
    );
});

Layout.displayName = 'MobileChatLayout';

export default Layout;
