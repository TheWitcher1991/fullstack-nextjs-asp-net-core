import { z } from 'zod'

import {
	CategorySchema,
	CreateCategorySchema,
	UpdateCategorySchema,
} from '~models/category/category.schema'

export type ICategory = z.infer<typeof CategorySchema>

export type ICreateCategory = z.infer<typeof CreateCategorySchema>

export type IUpdateCategory = z.infer<typeof UpdateCategorySchema>

export type UseCategories = UseModelOptions
