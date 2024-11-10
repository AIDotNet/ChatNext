
import { SideNav } from '@lobehub/ui';
import { memo } from 'react';

import { useActiveTabKey } from '@/hooks/useActiveTabKey';

const Nav = memo(() => {
    const sidebarKey = useActiveTabKey();
    return (
        <>

        </>
    );
});

Nav.displayName = 'DesktopNav';

export default Nav;
