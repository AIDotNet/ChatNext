import { UserAuthState, initialAuthState } from './slices/auth/initialState';
import { CommonState, initialCommonState } from './slices/common/initialState';
import { UserPreferenceState, initialPreferenceState } from './slices/preference/initialState';

export type UserState =
    UserPreferenceState &
    UserAuthState &
    CommonState;

export const initialState: UserState = {
    ...initialPreferenceState,
    ...initialAuthState,
    ...initialCommonState
};
