import { ActionIcon } from '@lobehub/ui';
import { Compass, MessageSquare, Images } from 'lucide-react';
import { useNavigate } from 'react-router-dom';
import { memo, startTransition } from 'react';

import { useGlobalStore } from '@/store/global';
import { SidebarTabKey } from '@/store/global/initialState';
import { useSessionStore } from '@/store/session';

export interface TopActionProps {
    tab?: SidebarTabKey;
}

const TopActions = memo<TopActionProps>(({ tab }) => {
    const navigate = useNavigate();
    const switchBackToChat = useGlobalStore((s) => s.switchBackToChat);

    return (
        <>
            <div
                aria-label={"聊天"}
                onClick={(e) => {
                    e.preventDefault();
                    startTransition(() => {
                        switchBackToChat(useSessionStore.getState().activeId);
                        startTransition(() => {
                            navigate('/chat' + location.search);
                        });
                    });
                }}
            >
                <ActionIcon
                    active={tab === SidebarTabKey.Chat}
                    icon={MessageSquare}
                    placement={'right'}
                    size="large"
                    title={"聊天"}
                />
            </div>
        </>
    );
});

export default TopActions;
