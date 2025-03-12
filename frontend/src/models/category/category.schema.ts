import { z } from 'zod'

import { zShape } from '~packages/schemas'

export const BaseCategorySchema = z.object({
	title: zShape.title,
})

export const CategorySchema = BaseCategorySchema.extend({
	id: zShape.id,
})

export const CreateCategorySchema = BaseCategorySchema.extend({
	topic: zShape.id,
})

export const UpdateCategorySchema = BaseCategorySchema
