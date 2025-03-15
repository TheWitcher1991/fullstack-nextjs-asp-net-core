import { accountServiceKeys } from '~models/account/account.config'
import {
	IAccount,
	ILogin,
	IRegister,
	IUpdateAccount,
} from '~models/account/account.types'

import { http } from '~packages/lib'

export class AccountRepository {
	static async login(data: ILogin) {
		return await http.post<
			ResultResponse<{
				token: string
				account: IAccount
			}>
		>(`${accountServiceKeys.login}`, data)
	}

	static async register(data: IRegister) {
		return await http.post<ResultResponse<string>>(
			`${accountServiceKeys.register}`,
			data,
		)
	}

	static async logout() {
		return await http.post<ResultResponse<string>>(
			`${accountServiceKeys.logout}`,
		)
	}

	static async profile() {
		return await http.get<ResultResponse<IAccount>>(
			`${accountServiceKeys.profile}`,
		)
	}

	static async updateProfile(data: IUpdateAccount) {
		return await http.put<ResultResponse<IAccount>>(
			`${accountServiceKeys.profile}`,
			data,
		)
	}
}
