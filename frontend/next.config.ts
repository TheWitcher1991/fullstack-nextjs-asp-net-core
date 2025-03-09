import type { NextConfig } from 'next'

const nextConfig: NextConfig = {
	compress: true,
	reactStrictMode: true,
	swcMinify: true,
	generateEtags: true,
	poweredByHeader: false,
	productionBrowserSourceMaps: false,
	crossOrigin: 'use-credentials',
	typescript: {
		ignoreBuildErrors: true,
	},
	eslint: {
		ignoreDuringBuilds: true,
	},
	images: {
		remotePatterns: [],
	},
	async rewrites() {
		return [
			{
				source: '/api/:path*',
				destination: 'https://localhost:8000/api/:path*',
			},
		]
	},
	webpack: config => {
		config.module.rules.push({
			test: /\.svg$/i,
			issuer: /\.[jt]sx?$/,
			use: ['@svgr/webpack'],
		})

		return config
	},
}

export default nextConfig
