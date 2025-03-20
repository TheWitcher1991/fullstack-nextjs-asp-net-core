import { z } from 'zod'

import { AccountSchema } from '~models/account'
import { BookSchema } from '~models/book'
import { EmotionSchema } from '~models/emotion'

import { zShape } from '~packages/schemas'

export const BaseImpressionSchema = z.object({
	text: zShape.text,
})

export const ImpressionSchema = BaseImpressionSchema.extend({
	id: zShape.id,
	book: BookSchema,
	user: AccountSchema.pick({
		id: true,
		firstName: true,
		lastName: true,
	}),
	emotions: EmotionSchema.array(),
})

export const ImpressionUserSchema = ImpressionSchema.omit({ user: true })

export const CreateImpressionSchema = BaseImpressionSchema.extend({
	emotions: zShape.id.array(),
	user: zShape.id,
	book: zShape.id,
})

export const UpdateImpressionSchema = BaseImpressionSchema.extend({
	emotions: zShape.id.array(),
})
