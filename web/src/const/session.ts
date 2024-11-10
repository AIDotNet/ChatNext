import { DEFAULT_AGENT_META, DEFAULT_INBOX_AVATAR } from '@/const/meta';
// import { DEFAULT_AGENT_CONFIG } from '@/const/settings';
import { LobeAgentSession, LobeSessionType } from '@/types/session';
import { merge } from '@/utils/merge';

export const INBOX_SESSION_ID = -1;

export const WELCOME_GUIDE_CHAT_ID = 'welcome';

export const DEFAULT_AGENT_LOBE_SESSION: LobeAgentSession = {
  // config: DEFAULT_AGENT_CONFIG,
  createdAt: new Date(),
  id: null,
  meta: DEFAULT_AGENT_META,
  groupId: '',
  model: 'gpt-4o-mini',
  type: LobeSessionType.Agent,
  updatedAt: new Date(),
  pinned: false,
  avatar: DEFAULT_INBOX_AVATAR,
  temperature: 0.7,
  title: '',
  provider: 'openai',
  topP: 1,
  systemRole: '',
  description: '',
  historyLimit: -1,
  presencePenalty: 0,
  plugins: [],
  config: [],
};

export const DEFAULT_INBOX_SESSION: LobeAgentSession = merge(DEFAULT_AGENT_LOBE_SESSION, {
  id: -1,
  meta: {
    avatar: DEFAULT_INBOX_AVATAR,
  },
});
