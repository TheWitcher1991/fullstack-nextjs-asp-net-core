import { z } from 'zod'

import { AccountSchema } from '~models/account'
import { CategorySchema } from '~models/category'

import { zShape } from '~packages/schemas'

export const BaseBookSchema = z.object({
	title: zShape.title,
	description: zShape.text,
	publisher: zShape.title,
	author: zShape.title,
	holder: zShape.string.nullable(),
	translator: zShape.string.nullable(),
	age: zShape.range(1, 120),
	pages: zShape.range(1, 1000),
})

export const BookSchema = BaseBookSchema.extend({
	id: zShape.id,
	imagePath: zShape.url,
	filePath: zShape.url,
	createdAt: zShape.datetime,
	categories: CategorySchema.array(),
	isFavorite: z.boolean(),
	user: AccountSchema.pick({
		id: true,
		firstName: true,
		lastName: true,
	}),
})

export const CreateBookSchema = BaseBookSchema.extend({
	categories: zShape.id.array(),
	user: zShape.id,
	image: zShape.image,
	file: zShape.file,
})

export const CreateBookFormSchema = BaseBookSchema.extend({
	categories: z.string().min(1),
	user: zShape.id,
	image: zShape.image,
	file: zShape.file,
	age: z.string().min(1),
	pages: z.string().min(1),
})

export const UpdateBookSchema = BaseBookSchema.extend({
	image: zShape.image.optional(),
	file: zShape.file.optional(),
})
