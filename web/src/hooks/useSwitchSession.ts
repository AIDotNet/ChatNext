import { useCallback } from 'react';
import { useNavigate } from 'react-router-dom';
import { useSessionStore } from '@/store/session';

export const useSwitchSession = () => {
    const switchSession = useSessionStore((s) => s.switchSession);
    const navigate = useNavigate();

    return useCallback(
        (id: number) => {
            switchSession(id);
            //   togglePortal(false);
            const chatPath = '/chat';
            navigate(`${chatPath}?id=${id}`, { replace: true });
        },
        [],
    );
};
