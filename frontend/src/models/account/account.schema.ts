import { z } from 'zod'

import { zShape } from '~packages/schemas'

export const AccountSchema = z.object({
	id: zShape.id,
	email: zShape.email,
	phone: zShape.phone,
	firstName: zShape.name,
	lastName: zShape.name,
	createdAt: zShape.datetime,
})

export const UpdateAccountSchema = AccountSchema.pick({
	email: true,
	phone: true,
	firstName: true,
	lastName: true,
})

export const RegisterSchema = AccountSchema.pick({
	email: true,
	phone: true,
	firstName: true,
	lastName: true,
}).extend({
	password: zShape.password,
})

export const LoginSchema = z.object({
	email: zShape.email,
	password: zShape.password,
})
