import ServerLayout from '@/components/server/ServerLayout';

import Desktop from './_layout/Desktop.tsx';
import Mobile from './_layout/Mobile.tsx';

const WelcomeLayout = ServerLayout({ Desktop, Mobile });

WelcomeLayout.displayName = 'WelcomeLayout';

export default WelcomeLayout;
