import { AxiosResponse } from 'axios'

import { accountServiceKeys } from '~models/account/account.config'
import {
	IAccount,
	ILogin,
	IRegister,
	IUpdateAccount,
} from '~models/account/account.types'

import { http } from '~packages/lib'

export class AccountRepository {
	static async login(data: ILogin): Promise<AxiosResponse<IAccount>> {
		return await http.post(`${accountServiceKeys.login}/`, data)
	}

	static async register(data: IRegister): Promise<AxiosResponse> {
		return await http.post(`${accountServiceKeys.register}/`, data)
	}

	static async logout(): Promise<AxiosResponse<string>> {
		return await http.post(`${accountServiceKeys.logout}/`)
	}

	static async profile(): Promise<AxiosResponse<IAccount>> {
		return await http.get(`${accountServiceKeys.profile}/`)
	}

	static async updateProfile(
		data: IUpdateAccount,
	): Promise<AxiosResponse<IAccount>> {
		return await http.put(`${accountServiceKeys.profile}/`, data)
	}
}
