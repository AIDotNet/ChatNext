import useSWR, { SWRResponse, mutate } from 'swr';
import { DeepPartial } from 'utility-types';
import { StateCreator } from 'zustand/vanilla';

import { DEFAULT_AGENT_LOBE_SESSION, INBOX_SESSION_ID } from '@/const/session';
import { SessionStore } from '@/store/session';
import { useUserStore } from '@/store/user';
import { MetaData } from '@/types/meta';
import {
  ChatSessionList,
  LobeAgentSession,
  LobeSessionGroups,
  LobeSessionType,
  LobeSessions,
  SessionGroupId,
} from '@/types/session';
import { merge } from '@/utils/merge';
const SEARCH_SESSIONS_KEY = 'searchSessions';

import { SessionDispatch, sessionsReducer } from './reducers';
import { useClientDataSWR } from '@/libs/swr';

const FETCH_SESSIONS_KEY = 'fetchSessions';

/* eslint-disable typescript-sort-keys/interface */
export interface SessionAction {
  /**
   * switch the session
   */
  switchSession: (sessionId: number) => void;
  /**
   * reset sessions to default
   */
  clearSessions: () => Promise<void>;
  /**
   * create a new session
   * @param agent
   * @returns sessionId
   */
  createSession: (
    session?: DeepPartial<LobeAgentSession>,
    isSwitchSession?: boolean,
  ) => Promise<number>;
  duplicateSession: (id: number) => Promise<void>;
  updateSessionGroupId: (sessionId: number, groupId: string) => Promise<void>;
  updateSessionMeta: (meta: Partial<MetaData>) => void;

  /**
   * Pins or unpins a session.
   */
  pinSession: (id: number, pinned: boolean) => Promise<void>;
  /**
   * re-fetch the data
   */
  refreshSessions: () => Promise<void>;
  /**
   * remove session
   * @param id - sessionId
   */
  removeSession: (id: number) => Promise<void>;

  updateSearchKeywords: (keywords: string) => void;

  useSearchSessions: (keyword?: string) => SWRResponse<any>;

  useFetchSessions: (isLogin: boolean | undefined) => SWRResponse<ChatSessionList>;

  internal_dispatchSessions: (payload: SessionDispatch) => void;
  internal_updateSession: (
    id: number,
    data: Partial<{ group?: SessionGroupId; meta?: any; pinned?: boolean }>,
  ) => Promise<void>;
  internal_processSessions: (
    sessions: LobeSessions,
    customGroups: LobeSessionGroups,
    actions?: string,
  ) => void;
  /* eslint-enable */
}

export const createSessionSlice: StateCreator<
  SessionStore,
  [['zustand/devtools', never]],
  [],
  SessionAction
> = (set, get) => ({
  clearSessions: async () => {
    // await sessionService.removeAllSessions();
    await get().refreshSessions();
  },

  createSession: async (agent, isSwitchSession = true) => {
    // const { switchSession, refreshSessions } = get();

    // // merge the defaultAgent in settings
    // const defaultAgent = merge(
    //   DEFAULT_AGENT_LOBE_SESSION,
    //   settingsSelectors.defaultAgent(useUserStore.getState()),
    // );

    // const newSession: LobeAgentSession = merge(defaultAgent, agent);

    // const id = await sessionService.createSession(LobeSessionType.Agent, newSession);
    // await refreshSessions();

    // // Whether to goto  to the new session after creation, the default is to switch to
    // if (isSwitchSession) switchSession(id);

    // return id;
    return -1;
  },

  duplicateSession: async (id) => {

  },
  pinSession: async (id, pinned) => {
    await get().internal_updateSession(id, { pinned });
  },

  removeSession: async (sessionId) => {

  },

  switchSession: (sessionId) => {

  },

  updateSearchKeywords: (keywords) => {

  },
  updateSessionGroupId: async (sessionId, group) => {
    await get().internal_updateSession(sessionId, { group });
  },

  updateSessionMeta: async (meta) => {

  },


  /* eslint-disable sort-keys-fix/sort-keys-fix */
  internal_dispatchSessions: (payload) => {
    const nextSessions = sessionsReducer(get().sessions, payload);
    // get().internal_processSessions(nextSessions, get().sessionGroups);
  },
  internal_updateSession: async (id, data) => {
    get().internal_dispatchSessions({ type: 'updateSession', id, value: data });

    await get().refreshSessions();
  },
  internal_processSessions: (sessions, sessionGroups) => {
    const customGroups = sessionGroups.map((item) => ({
      ...item,
      children: sessions.filter((i) => i.group === item.id && !i.pinned),
    }));

    const defaultGroup = sessions.filter(
      (item) => (!item.group || item.group === 'default') && !item.pinned,
    );
    const pinnedGroup = sessions.filter((item) => item.pinned);

    set(
      {
        // customSessionGroups: customGroups,
        defaultSessions: defaultGroup,
        pinnedSessions: pinnedGroup,
        // sessionGroups,
        sessions,
      },
      false,
      'internal_processSessions',
    );
  },
  refreshSessions: async () => {
    await mutate([FETCH_SESSIONS_KEY, true]);
  },
  useSearchSessions: (keyword) =>
    useSWR<LobeSessions>(
      [SEARCH_SESSIONS_KEY, keyword],
      async () => {
        if (!keyword) return [];

        // return sessionService.searchSessions(keyword);
        return [];
      },
      { revalidateOnFocus: false, revalidateOnMount: false },
    ),

  useFetchSessions: (isLogin) =>
    useClientDataSWR<ChatSessionList>(
      [FETCH_SESSIONS_KEY, isLogin],
      // () => sessionService.getGroupedSessions(),
      () => ({} as ChatSessionList),
      {
        fallbackData: {
          sessionGroups: [],
          sessions: [],
        },
        onSuccess: (data) => {
          if (
            get().isSessionsFirstFetchFinished
            // &&
            // isEqual(get().sessions, data.sessions) &&
            // isEqual(get().sessionGroups, data.sessionGroups)
          )
            return;

          get().internal_processSessions(
            data.sessions,
            data.sessionGroups,
            '更新会话列表',
          );
          set({ isSessionsFirstFetchFinished: true }, false, '更新会话列表完成');
        },
        suspense: true,
      },
    ),
});
