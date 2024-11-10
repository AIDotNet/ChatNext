import { LobeChatProps } from '@lobehub/ui/brand';
import { memo } from 'react';

import CustomLogo from './Custom';

export const ProductLogo = memo<LobeChatProps>((props) => {
    return <CustomLogo {...props} />;
});
