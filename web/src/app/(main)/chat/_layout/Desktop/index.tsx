import { Flexbox } from 'react-layout-kit';
import SessionPanel from './SessionPanel';
import Session from '../../@session';
const Layout = () => {

    return (
        <>
            <Flexbox
                height={'100%'}
                horizontal
                style={{ maxWidth: '100%', overflow: 'hidden', position: 'relative' }}
                width={'100%'}
            >
                <SessionPanel>
                    <Session />
                </SessionPanel>
                <Flexbox flex={1} style={{ overflow: 'hidden', position: 'relative' }}>
                    Chat
                </Flexbox>
            </Flexbox>
        </>
    );
};

Layout.displayName = 'DesktopChatLayout';

export default Layout;
