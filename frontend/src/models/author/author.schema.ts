import { z } from 'zod'

import { zShape } from '~packages/schemas'

export const BaseAuthorSchema = z.object({
	title: zShape.title,
	fullName: zShape.name,
	about: zShape.text,
})

export const AuthorSchema = BaseAuthorSchema.extend({
	id: zShape.id,
	avatarPath: zShape.url,
	createdAt: zShape.datetime,
})
