import { memo } from 'react';

import CustomLogo from './Custom';

export const WelcomeLogo = memo<{ mobile?: boolean }>(({ mobile }) => {
    return <CustomLogo mobile={mobile} />;
});
