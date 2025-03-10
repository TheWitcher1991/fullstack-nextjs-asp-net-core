import { z } from 'zod'

import {
	AccountSchema,
	LoginSchema,
	RegisterSchema,
	UpdateAccountSchema,
} from '~models/account/account.schema'

export type IAccount = z.infer<typeof AccountSchema>

export type IUpdateAccount = z.infer<typeof UpdateAccountSchema>

export type IRegister = z.infer<typeof RegisterSchema>

export type ILogin = z.infer<typeof LoginSchema>
