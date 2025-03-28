import { create } from 'zustand'
import { persist } from 'zustand/middleware'

import { IAccount } from '~models/account/account.types'

type AccountStore = {
	account: Nullable<IAccount>
	login: (account: Partial<IAccount>) => void
	logout: () => void
}

export const useAccountStore = create<AccountStore>(
	persist(
		set => ({
			account: null,
			login: account => set(state => ({ ...state, account })),
			logout: () => set({ account: null }),
		}),
		{
			name: 'account-storage',
		},
	),
)

export const account = useAccountStore.getState().account

export const accountFullName = `${account?.firstName} ${account?.lastName}`

export const logout = useAccountStore.getState().logout

export const login = useAccountStore.getState().login
