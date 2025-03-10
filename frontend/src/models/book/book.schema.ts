import { z } from 'zod'

import { AccountSchema } from '~models/account'
import { CategorySchema } from '~models/category'
import { TopicSchema } from '~models/topic'

import { zShape } from '~packages/schemas'

export const BaseBookSchema = z.object({
	title: zShape.title,
	description: zShape.text,
	price: zShape.decimal,
})

export const BookSchema = BaseBookSchema.extend({
	id: zShape.id,
	imagePath: zShape.url,
	filePath: zShape.url,
	createdAt: zShape.datetime,
	topic: TopicSchema,
	category: CategorySchema,
	user: AccountSchema,
})

export const CreateBookSchema = BaseBookSchema.extend({
	topic: zShape.id,
	category: zShape.id,
	user: zShape.id,
	image: zShape.image,
	file: zShape.file,
})

export const UpdateBookSchema = BaseBookSchema.extend({
	image: zShape.image.optional(),
	file: zShape.file.optional(),
})
